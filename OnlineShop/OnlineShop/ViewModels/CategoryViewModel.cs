using OnlineShop.Models;
using OnlineShop.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
