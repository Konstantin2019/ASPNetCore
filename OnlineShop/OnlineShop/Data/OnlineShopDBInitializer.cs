using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineShop.DB.Context;
using OnlineShop.Domain.Models.Identity;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Data
{
    public class OnlineShopDBInitializer
    {
        private readonly OnlineShopDB dbcontext;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly ILogger<OnlineShopDBInitializer> logger;

        public OnlineShopDBInitializer(OnlineShopDB dbcontext, 
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            ILogger<OnlineShopDBInitializer> logger)
        {
            this.dbcontext = dbcontext;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.logger = logger;
        }
        public void Initialize()
        {
            var timer = Stopwatch.StartNew();
            logger.LogInformation("Database initialization...");
            var db = dbcontext.Database;
            if (db.GetPendingMigrations().Any()) 
            {
                logger.LogInformation("Performing migration...");
                db.Migrate();
                logger.LogInformation("Migration have been successfull!");
            }
            else
            {
                logger.LogInformation($"Database is in actual state ({timer.Elapsed.TotalSeconds} c)!");
            }
            try
            {
                InitializeCatalog();
            }
            catch (Exception error)
            {
                logger.LogInformation("Database initialization have been failed!");
                logger.LogInformation(error.Message);
                throw;
            }
            logger.LogInformation($"Database initialization have been succcessfull ({timer.Elapsed.TotalSeconds} c)!");
        }
        public void InitializeCatalog() 
        {
            if (dbcontext.Products.Any()) 
            {
                logger.LogInformation("Catalog initialization is not required!");
                return;
            }
            var timer = Stopwatch.StartNew();
            logger.LogInformation("Catalog initialization...");
            logger.LogInformation("Categories initialization...");
            using (dbcontext.Database.BeginTransaction())
            {
                dbcontext.Categories.AddRange(CategoriesData.categories);
                dbcontext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Categories] ON");
                dbcontext.SaveChanges();
                dbcontext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Categories] OFF");
                dbcontext.Database.CommitTransaction();
            }
            logger.LogInformation("Categories initialization have been succcessfull!");
            logger.LogInformation("Brands initialization...");
            using (dbcontext.Database.BeginTransaction())
            {
                dbcontext.Brands.AddRange(BrandsData.brands);
                dbcontext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Brands] ON");
                dbcontext.SaveChanges();
                dbcontext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Brands] OFF");
                dbcontext.Database.CommitTransaction();
            }
            logger.LogInformation("Brands initialization have been succcessfull!");
            logger.LogInformation("Products initialization...");
            using (dbcontext.Database.BeginTransaction())
            {
                dbcontext.Products.AddRange(ProductsData.products);
                dbcontext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Products] ON");
                dbcontext.SaveChanges();
                dbcontext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Products] OFF");
                dbcontext.Database.CommitTransaction();
            }
            logger.LogInformation("Products initialization have been succcessfull!");
            logger.LogInformation($"Catalog initialization have been succcessfull ({timer.Elapsed.TotalSeconds} c)!");
        }
        public async Task InitializeIdentity() 
        {
            var timer = Stopwatch.StartNew();
            logger.LogInformation("Identity initialization...");

            async Task RoleCheck(string role) 
            {
                if (!await roleManager.RoleExistsAsync(role)) 
                {
                    logger.LogInformation($"{role} isn't finded, creating...");
                    await roleManager.CreateAsync(new Role { Name = role });
                    logger.LogInformation($"{role} have been successfully created!");
                }
            }

            await RoleCheck(Role.administrator);
            await RoleCheck(Role.users);

            if (await userManager.FindByNameAsync(User.administrator) is null) 
            {
                logger.LogInformation("Administrator isn't finded, creating...");
                var admin = new User { UserName = User.administrator };
                var creationResult = await userManager.CreateAsync(admin, User.defaultAdminPassword);
                if (creationResult.Succeeded) 
                {
                    logger.LogInformation("Administrator have been successfully created!");
                    await userManager.AddToRoleAsync(admin, Role.administrator);
                    logger.LogInformation("Administrator have been recieved admin role");
                }
                    
                else
                {
                    logger.LogInformation("Administrator creation is failed!");
                    var errors = creationResult.Errors.Select(e => e.Description);
                    throw new InvalidOperationException($"Admin initialization error : {string.Join(",", errors)}");
                }
            }

            logger.LogInformation("Identity initialization have been successfull!");
        }
    }
}
