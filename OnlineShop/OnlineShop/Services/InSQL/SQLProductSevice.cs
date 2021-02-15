using Microsoft.EntityFrameworkCore;
using OnlineShop.DB.Context;
using OnlineShop.Domain.Models;
using OnlineShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Services.InSQL
{
    public class SQLProductSevice : IProductService
    {
        private readonly OnlineShopDB dbcontext;

        public SQLProductSevice(OnlineShopDB dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public IEnumerable<Brand> GetBrands() => dbcontext.Brands.Include(d => d.Products);

        public IEnumerable<Category> GetCategories() => dbcontext.Categories.Include(d => d.Products);

        public Product GetProductById(int id) => dbcontext.Products.Include(p => p.Brand)
                                                                   .Include(p => p.Category)
                                                                   .FirstOrDefault(p => p.Id == id);

        public IEnumerable<Product> GetProducts(ProductFilter filter = null)
        {
            IQueryable<Product> query = dbcontext.Products
                                                 .Include(p => p.Brand)
                                                 .Include(p => p.Category);
            if (filter is null)
                return query;
            if (filter.Ids?.Length > 0)
                query.Where(p => filter.Ids.Contains(p.Id));
            else
            {
                if (filter?.CategoryId is { } category_id)
                    query = query.Where(q => q.CategoryId == category_id);
                if (filter?.BrandId is { } brand_id)
                    query = query.Where(q => q.BrandId == brand_id);
            }
            return query;
        }
        public int Add(Product product) 
        {
            if (product is null)
                throw new ArgumentNullException(nameof(Product));
            if (dbcontext.Products.Contains(product))
                return product.Id;
            using (dbcontext.Database.BeginTransaction())
            {
                dbcontext.Products.Add(product);
                dbcontext.SaveChanges();
                dbcontext.Database.CommitTransaction();
            }
            return product.Id;
        }
        public void Update(Product product) 
        {
            using (dbcontext.Database.BeginTransaction())
            {
                var item = GetProductById(product.Id);

                item.Brand.Name = product.Brand.Name;
                item.Name = product.Name;
                item.Order = product.Order;
                item.Price = product.Price;
                item.ImageUrl = product.ImageUrl;

                dbcontext.SaveChanges();
                dbcontext.Database.CommitTransaction();
            }
        }
        public bool Delete(int id) 
        {
            var product = GetProductById(id);
            if (product is not null)
            {
                using (dbcontext.Database.BeginTransaction())
                {
                    dbcontext.Products.Remove(product);
                    dbcontext.SaveChanges();
                    dbcontext.Database.CommitTransaction();
                }
                return true;
            }
            else
                return false;
        }
    }
}
