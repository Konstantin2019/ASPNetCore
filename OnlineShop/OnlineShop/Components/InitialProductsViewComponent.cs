using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services.Interfaces;
using OnlineShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Components
{
    public class InitialProductsViewComponent : ViewComponent
    {
        private IProductService productService;
        public InitialProductsViewComponent(IProductService productService)
        {
            this.productService = productService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var initProducts = await GetInitialProducts();
            return View(initProducts);
        }
        private Task<List<ProductViewModel>> GetInitialProducts()
        {
            var task = Task.Run(() =>
            {
                var products = productService.GetProducts()
                                 .OrderBy(p => p.Order)
                                 .Take(6)
                                 .Select(p => new ProductViewModel
                                 {
                                     Id = p.Id,
                                     Name = p.Name,
                                     Price = p.Price,
                                     ImageUrl = p.ImageUrl,
                                     Order = p.Order
                                 });
                return products.ToList();
            });
            return task;
        }
    }
}
