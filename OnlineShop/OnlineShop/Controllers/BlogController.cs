using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index() => View("Blog");
        public IActionResult Single() => View("Single");
    }
}
