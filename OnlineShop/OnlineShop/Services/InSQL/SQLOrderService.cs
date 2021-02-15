using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShop.DB.Context;
using OnlineShop.Domain.Models;
using OnlineShop.Domain.Models.Identity;
using OnlineShop.Services.Interfaces;
using OnlineShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Services.InSQL
{
    public class SQLOrderService : IOrderService
    {
        private readonly OnlineShopDB db;
        private readonly UserManager<User> userManager;

        public SQLOrderService(OnlineShopDB db, UserManager<User> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        public async Task<Order> GetOrderById(int id) =>
            await db.Orders.Include(o => o.User)
                           .Include(o => o.Items)
                           .FirstOrDefaultAsync(o => o.Id == id);

        public async Task<IEnumerable<Order>> GetUserOrders(string userName) =>
            await db.Orders.Include(o => o.User)
                           .Include(o => o.Items)
                           .Where(o => o.User.UserName == userName).ToArrayAsync();

        public async Task<Order> CreateOrder(string userName, CartViewModel cartViewModel, OrderViewModel orderViewModel)
        {
            var user = await userManager.FindByNameAsync(userName);
            if (user is null)
                throw new InvalidOperationException($"User {userName} isn't finded!");
            await using var transaction = await db.Database.BeginTransactionAsync().ConfigureAwait(false);
            var order = new Order
            {
                Name = orderViewModel.Name,
                Phone = orderViewModel.Phone,
                Address = orderViewModel.Address,
                User = user
            };
            var productIds = cartViewModel.Items.Select(i => i.product.Id).ToArray();
            var cartItems = await db.Products.Where(p => productIds.Contains(p.Id)).ToArrayAsync();
            order.Items = cartViewModel.Items
                                       .Join(cartItems,
                                             cartItem => cartItem.product.Id,
                                             product => product.Id,
                                             (cartItem, product) => new OrderItem
                                             {
                                                 Order = order,
                                                 Product = product,
                                                 Price = product.Price,
                                                 Quantity = cartItem.quantity,
                                             }).ToArray();
            await db.Orders.AddAsync(order);
            await db.SaveChangesAsync();
            await transaction.CommitAsync();
            return order;
        }
    }
}
