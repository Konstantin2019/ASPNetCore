using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineShop.Data;
using OnlineShop.DB.Context;
using OnlineShop.Domain.Models;
using OnlineShop.InMemory.Services;
using OnlineShop.Services.InSQL;
using OnlineShop.Services.Interfaces;
using System;

namespace OnlineShop
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<OnlineShopDB>(conf => conf
                    .UseSqlServer(Configuration.GetConnectionString("Default")));

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<OnlineShopDB>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 6;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                options.User.RequireUniqueEmail = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.Expiration = TimeSpan.FromDays(30);
                options.LoginPath = "/Account/Login"; 
                options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath = "/Account/AccessDenied"; 
                options.SlidingExpiration = true;
            });

            services.AddTransient<OnlineShopDBInitializer>();

            services.AddTransient<IEmployeeSevice, InMemoryEmployeeService>();

            //services.AddTransient<IProductService, InMemoryProductService>();

            services.AddTransient<IProductService, SQLProductSevice>();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, OnlineShopDBInitializer db)
        {
            db.Initialize();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
