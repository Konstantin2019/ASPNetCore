using OnlineShop.Domain.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Domain.Models
{
    public record Category: OrderedEntity 
    {
        public int? ParentId { get; init; }

        [ForeignKey(nameof(ParentId))]
        public Category Parent { get; init; }
        public ICollection<Product> Products { get; init; }
    }
}
