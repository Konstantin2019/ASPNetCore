using System.Collections.Generic;

namespace OnlineShop.ViewModels
{
    public class CatalogViewModel
    {
        public int? BrandId { get; init; }
        public int? CategoryId { get; init; }
        public IEnumerable<ProductViewModel> Products { get; set; }

    }
}
