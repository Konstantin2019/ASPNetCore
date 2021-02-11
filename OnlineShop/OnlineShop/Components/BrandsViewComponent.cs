using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services.Interfaces;
using OnlineShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Components
{
    public class BrandsViewComponent : ViewComponent
    {
        private readonly IProductService productService;
        public BrandsViewComponent(IProductService productService)
        {
            this.productService = productService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var brands = await GetBrands();
            return View(brands);
        }
        private Task<List<BrandViewModel>> GetBrands()
        {
            var task = Task.Run(() => 
            {
                var brands = productService.GetBrands();
                return brands.Select(b => new BrandViewModel
                {
                    Id = b.Id,
                    Name = b.Name,
                    Order = b.Order,
                    ProductsCount = 0
                }).OrderBy(b => b.Order).ToList();
            });
            return task;
        }

    }
}
