using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.ViewModels
{
    public class CartViewModel
    {
        public IEnumerable<(ProductViewModel product, int quantity)> Items { get; set; }
        public int ItemsCount => Items?.Sum(i => i.quantity) ?? 0;
        public decimal TotalPrice => Items?.Sum(i => i.product.Price * i.quantity) ?? 0;
    }
}
