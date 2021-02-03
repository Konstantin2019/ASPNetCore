using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Domain.Models;
using OnlineShop.ViewModels;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpGet]
        public IActionResult Register() => View(new RegisterUserViewModel());

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel model) 
        {
            if (!ModelState.IsValid) return View(model);

            var user = new User 
            {
                UserName = model.UserName 
            };
            var request = await userManager.CreateAsync(user, model.Password);

            if (request.Succeeded)
            {
                await signInManager.SignInAsync(user, false);
                RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var identityError in request.Errors)
                {
                    ModelState.AddModelError("", identityError.Description);
                }
            }

            return View(model);
        }
    }
}
