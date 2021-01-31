using OnlineShop.Models.Base;
using System.Collections.Generic;

namespace OnlineShop.Models
{
    public class Brand : OrderedEntity 
    {
        public int ProductsCount { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
