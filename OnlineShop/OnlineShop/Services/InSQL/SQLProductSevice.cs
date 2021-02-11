using Microsoft.EntityFrameworkCore;
using OnlineShop.DB.Context;
using OnlineShop.Domain.Models;
using OnlineShop.Services.Interfaces;
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
            IQueryable<Product> query = dbcontext.Products;
            if (filter is null)
                return query;
            if (filter?.CategoryId is { } category_id)
                query = query.Where(q => q.CategoryId == category_id);
            if (filter?.BrandId is { } brand_id)
                query = query.Where(q => q.BrandId == brand_id);
            return query;
        }
    }
}
