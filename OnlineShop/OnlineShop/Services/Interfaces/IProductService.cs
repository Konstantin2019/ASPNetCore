using OnlineShop.Domain.Models;
using System.Collections.Generic;

namespace OnlineShop.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Category> GetCategories();
        IEnumerable<Brand> GetBrands();
        IEnumerable<Product> GetProducts(ProductFilter filter = null);
        Product GetProductById(int id);
        int Add(Product product); 
        void Update(Product product);
        bool Delete(int id);
    }
}
