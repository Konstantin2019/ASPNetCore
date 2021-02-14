using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Domain.Models.Identity;
using OnlineShop.ViewModels;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string returnUrl) => View(new LoginUserViewModel { ReturnUrl = returnUrl });

        [AllowAnonymous]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var login_result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, true);

            if (login_result.Succeeded)
                return LocalRedirect(model.ReturnUrl ?? "/");
            else
                ModelState.AddModelError("", "Incorrect login or passsword!");

            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register() => View(new RegisterUserViewModel());

        [AllowAnonymous]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = new User
            {
                UserName = model.UserName
            };
            var reg_result = await userManager.CreateAsync(user, model.Password);

            if (reg_result.Succeeded)
            {
                await signInManager.SignInAsync(user, false);
                await userManager.AddToRoleAsync(user, Role.users);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var identityError in reg_result.Errors)
                {
                    ModelState.AddModelError("", identityError.Description);
                }
            }

            return View(model);
        }

        public async Task<IActionResult> Logout() 
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
    }
}
