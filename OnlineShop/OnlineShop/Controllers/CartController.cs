using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services.Interfaces;
using OnlineShop.ViewModels;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        public IActionResult Index() => View(new CartOrderViewModel 
        { 
            Cart = cartService.GetViewModel()
        });

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

        [Authorize]
        public async Task<IActionResult> CheckOut(OrderViewModel orderViewModel, [FromServices] IOrderService orderService) 
        {
            if (!ModelState.IsValid)
                return View(nameof(Index), new CartOrderViewModel
                {
                    Cart = cartService.GetViewModel(),
                    Order = orderViewModel
                });
            var order = await orderService.CreateOrder(User.Identity!.Name,
                                                       cartService.GetViewModel(),
                                                       orderViewModel);
            cartService.Clear();
            return RedirectToAction(nameof(OrderConfirmed), new { order.Id });
        }
        public IActionResult OrderConfirmed(int id) 
        {
            ViewBag.OrderId = id;
            return View();
        }
    }
}
