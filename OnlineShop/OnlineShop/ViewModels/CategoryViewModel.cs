using OnlineShop.Domain.Models.Base;
using System.Collections.Generic;

namespace OnlineShop.ViewModels
{
    public record CategoryViewModel : OrderedEntity
    {
        public List<CategoryViewModel> Child { get; set; } = new();
        public CategoryViewModel Parent { get; init; }
    }
}
