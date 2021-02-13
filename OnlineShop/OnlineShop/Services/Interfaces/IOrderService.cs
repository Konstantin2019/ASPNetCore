using OnlineShop.Domain.Models;
using OnlineShop.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetUserOrders(string name);
        Task<Order> GetOrderById(int id);
        Task<Order> CreateOrder(string userName, CartViewModel cartViewModel, OrderViewModel orderViewModel);
    }
}
