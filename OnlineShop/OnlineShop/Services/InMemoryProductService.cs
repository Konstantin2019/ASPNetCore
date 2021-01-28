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
        private readonly IEnumerable<Category> categories;
        private readonly IEnumerable<Brand> brands;

        public IEnumerable<Brand> GetBrands() => brands;

        public IEnumerable<Category> GetCategories() => categories;
    }
}
