using OnlineShop.Domain.Models;
using System.Collections.Generic;

namespace OnlineShop.Services.Interfaces
{
    public interface IProductService
    {
        public IEnumerable<Category> GetCategories();
        public IEnumerable<Brand> GetBrands();
        public IEnumerable<Product> GetProducts(ProductFilter filter = null);
    }
}
