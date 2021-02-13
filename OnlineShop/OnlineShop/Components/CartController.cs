using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services.Interfaces;

namespace OnlineShop.Components
{
    public class CartController : Controller
    {
        private readonly ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        public IActionResult Index() => View(cartService.GetViewModel());

        public IActionResult Increment(int id) 
        {
            cartService.Increment(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Decrement(int id)
        {
            cartService.Decrement(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Remove(int id)
        {
            cartService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Clear()
        {
            cartService.Clear();
            return RedirectToAction(nameof(Index));
        }
    }
}
