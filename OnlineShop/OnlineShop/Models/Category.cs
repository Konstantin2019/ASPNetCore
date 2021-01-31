using OnlineShop.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Models
{
    public class Category: OrderedEntity 
    {
        public int? ParentId { get; set; }

        [ForeignKey(nameof(ParentId))]
        public Category Parent { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
