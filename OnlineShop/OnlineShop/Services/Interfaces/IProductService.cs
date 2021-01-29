using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Services.Interfaces
{
    public interface IProductService
    {
        public IEnumerable<Category> GetCategories();
        public IEnumerable<Brand> GetBrands();
        public IEnumerable<Product> GetProducts(ProductFilter filter);
    }
}
