using OnlineShop.Domain.Models.Base;

namespace OnlineShop.ViewModels
{
    public class ProductViewModel : OrderedEntity
    {
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}
