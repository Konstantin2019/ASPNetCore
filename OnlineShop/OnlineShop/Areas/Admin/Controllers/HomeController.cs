using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Domain.Models.Identity;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = Role.administrator)]
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}
