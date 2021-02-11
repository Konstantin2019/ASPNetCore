using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index() => View("Error");
    }
}
