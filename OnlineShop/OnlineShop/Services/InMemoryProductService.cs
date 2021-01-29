using OnlineShop.Data;
using OnlineShop.Models;
using OnlineShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Services
{
    public class InMemoryProductService : IProductService
    {
        public IEnumerable<Brand> GetBrands() => BrandsData.brands;

        public IEnumerable<Category> GetCategories() => CategoriesData.categories;

        public IEnumerable<Product> GetProducts(ProductFilter filter)
        {
            var query = ProductsData.products;
            if (filter?.CategoryId is { } category_id)
                query = query.Where(q => q.CategoryId == category_id).ToList();
            if (filter?.BrandId is { } brand_id)
                query = query.Where(q => q.BrandId == brand_id).ToList();
            return query;
        }
    }
}
