using OnlineShop.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.ViewModels
{
    public class ProductViewModel : OrderedEntity
    {
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}
