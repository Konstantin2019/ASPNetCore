using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Domain.Models;
using OnlineShop.Domain.Models.Identity;
using OnlineShop.Services.Interfaces;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = Role.administrator)]
    public class HomeController : Controller
    {
        private readonly IProductService productService;

        public HomeController(IProductService productService)
        {
            this.productService = productService;
        }
        public IActionResult Index() => View();

        public IActionResult ProductList()
        {
            var products = productService.GetProducts(new ProductFilter());
            return View(products);
        }

    }
}
