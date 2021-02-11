using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineShop.DB.Context;
using System;
using System.Diagnostics;
using System.Linq;

namespace OnlineShop.Data
{
    public class OnlineShopDBInitializer
    {
        private readonly OnlineShopDB dbcontext;
        private readonly ILogger<OnlineShopDBInitializer> logger;

        public OnlineShopDBInitializer(OnlineShopDB dbcontext, ILogger<OnlineShopDBInitializer> logger)
        {
            this.dbcontext = dbcontext;
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
                logger.LogInformation("Migration was successfull!");
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
                logger.LogInformation("Database initialization was failed!");
                logger.LogInformation(error.Message);
                throw;
            }
            logger.LogInformation($"Database initialization was succcessfull ({timer.Elapsed.TotalSeconds} c)!");
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
            logger.LogInformation("Categories initialization was succcessfull!");
            logger.LogInformation("Brands initialization...");
            using (dbcontext.Database.BeginTransaction())
            {
                dbcontext.Brands.AddRange(BrandsData.brands);
                dbcontext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Brands] ON");
                dbcontext.SaveChanges();
                dbcontext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Brands] OFF");
                dbcontext.Database.CommitTransaction();
            }
            logger.LogInformation("Brands initialization was succcessfull!");
            logger.LogInformation("Products initialization...");
            using (dbcontext.Database.BeginTransaction())
            {
                dbcontext.Products.AddRange(ProductsData.products);
                dbcontext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Products] ON");
                dbcontext.SaveChanges();
                dbcontext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Products] OFF");
                dbcontext.Database.CommitTransaction();
            }
            logger.LogInformation("Products initialization was succcessfull!");
            logger.LogInformation($"Catalog initialization was succcessfull ({timer.Elapsed.TotalSeconds} c)!");
        }
    }
}
