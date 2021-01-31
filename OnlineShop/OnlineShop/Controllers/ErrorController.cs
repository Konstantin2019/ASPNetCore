using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index() => View("Error");
    }
}
