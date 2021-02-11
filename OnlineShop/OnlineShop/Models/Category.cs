using OnlineShop.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class Category: OrderedEntity 
    {
        public int? ParentId { get; set; }
    }
}
