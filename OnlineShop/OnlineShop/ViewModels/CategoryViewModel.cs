using OnlineShop.Domain.Models.Base;
using System.Collections.Generic;

namespace OnlineShop.ViewModels
{
    public class CategoryViewModel : OrderedEntity
    {
        public List<CategoryViewModel> Child { get; set; }
        public CategoryViewModel Parent { get; set; }
        public CategoryViewModel()
        {
            Child = new List<CategoryViewModel>();
        }
    }
}
