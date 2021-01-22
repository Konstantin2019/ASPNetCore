using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index() => View("Products");
        public IActionResult Details() => View("Details");
        public IActionResult Checkout() => View("Checkout");
        public IActionResult Cart() => View("Cart");
        public IActionResult Login() => View("Login");
    }
}
