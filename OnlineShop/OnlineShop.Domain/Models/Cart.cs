using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Domain.Models
{
    public record Cart
    {
        public ICollection<CartItem> Items { get; set; } = new List<CartItem>();
        public int ItemsCount => Items?.Sum(i => i.Quantity) ?? 0;
    }
}
