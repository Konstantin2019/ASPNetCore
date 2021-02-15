using System.Collections.Generic;

namespace OnlineShop.ViewModels
{
    public record CatalogViewModel
    {
        public int? BrandId { get; init; }
        public int? CategoryId { get; init; }
        public IEnumerable<ProductViewModel> Products { get; init; }

    }
}
