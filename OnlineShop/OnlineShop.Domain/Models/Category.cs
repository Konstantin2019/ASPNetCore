using OnlineShop.Domain.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Domain.Models
{
    public class Category: OrderedEntity 
    {
        public int? ParentId { get; set; }

        [ForeignKey(nameof(ParentId))]
        public Category Parent { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
