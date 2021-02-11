using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using OnlineShop.Domain.Models;
using OnlineShop.Services.Extensions;
using OnlineShop.Services.Interfaces;
using OnlineShop.ViewModels;
using System.Linq;

namespace OnlineShop.Services.InCookies
{
    public class CartService : ICartService
    {
        private readonly IHttpContextAccessor httpAccessor;
        private readonly IProductService productService;
        private readonly string cartName;

        private Cart Cart 
        {
            get 
            {
                var context = httpAccessor.HttpContext;
                var cookies = context.Response.Cookies;
                var cartCookies = context.Request.Cookies[cartName];
                if (cartCookies is null) 
                {
                    var cart = new Cart();
                    cookies.Append(cartName, JsonConvert.SerializeObject(cart));
                    return cart;
                }
                ReplaceCookies(cookies, cartCookies);
                return JsonConvert.DeserializeObject<Cart>(cartCookies);
            }
            set => ReplaceCookies(httpAccessor.HttpContext.Response.Cookies, JsonConvert.SerializeObject(value));
        }

        public CartService(IHttpContextAccessor httpAccessor, IProductService productService)
        {
            this.httpAccessor = httpAccessor;
            this.productService = productService;
            var user = httpAccessor.HttpContext.User;
            var userName = user.Identity!.IsAuthenticated ? $"{user.Identity.Name}" : null;
            cartName = $"Cart_{userName}";
        }

        private void ReplaceCookies(IResponseCookies cookies, string cookie) 
        {
            cookies.Delete(cartName);
            cookies.Append(cartName, cookie);
        }

        public void Increment(int id)
        {
            var cart = Cart;
            var item = cart.Items.FirstOrDefault(i => i.ProductId == id);
            if (item is null)
                cart.Items.Add(new CartItem { ProductId = id });
            else
                item.Quantity++;
            Cart = cart;
        }

        public void Decrement(int id)
        {
            var cart = Cart;
            var item = cart.Items.FirstOrDefault(i => i.ProductId == id);
            if (item is null) return;
            if (item.Quantity > 0)
                item.Quantity--;
            if (item.Quantity == 0)
                cart.Items.Remove(item);
            Cart = cart;
        }

        public void Remove(int id)
        {
            var cart = Cart;
            var item = cart.Items.FirstOrDefault(i => i.ProductId == id);
            if (item is null) return;
            cart.Items.Remove(item);
            Cart = cart;
        }

        public void Clear()
        {
            var cart = Cart;
            cart.Items.Clear();
            Cart = cart;
        }

        public CartViewModel GetViewModel()
        {
            var products = productService.GetProducts(new ProductFilter
            {
                Ids = Cart.Items.Select(i => i.ProductId).ToArray()
            });
            var productsViewModel = products.Select(p => p.ToView()).ToDictionary(p => p.Id);
            return new CartViewModel
            {
                Items = Cart.Items
                            .Where(i => productsViewModel.ContainsKey(i.ProductId))
                            .Select(i => (productsViewModel[i.ProductId], i.Quantity))
            };
        }
    }
}
