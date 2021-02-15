using OnlineShop.Domain.Models.Base;

namespace OnlineShop.ViewModels
{
    public record BrandViewModel : OrderedEntity
    {
        public int ProductsCount { get; init; }
    }
}
