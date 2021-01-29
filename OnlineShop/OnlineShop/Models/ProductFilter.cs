using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class ProductFilter
    {
        public int CategoryId { get; set; }
        public int? BrandId { get; set; }
    }
}
