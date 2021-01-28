using OnlineShop.Models;
using OnlineShop.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Components
{
    public class CategoryViewModel : OrderedEntity
    {
        public List<CategoryViewModel> ChildSections { get; set; }
        public CategoryViewModel ParentCategory { get; set; }
        public CategoryViewModel()
        {
            ChildSections = new List<CategoryViewModel>();
        }
    }
}
