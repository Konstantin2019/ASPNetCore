using OnlineShop.Domain.Models;
using OnlineShop.Domain.Models.Base;

namespace OnlineShop.ViewModels
{
    public class ProductViewModel : OrderedEntity
    {
        public string ImageUrl { get; init; }
        public decimal Price { get; init; }
        public Brand Brand { get; init; }
    }
}
