using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineShop.Data;
using OnlineShop.DB.Context;
using OnlineShop.InMemory.Services;
using OnlineShop.Services.InSQL;
using OnlineShop.Services.Interfaces;

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
