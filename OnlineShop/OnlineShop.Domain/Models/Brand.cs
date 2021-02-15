using OnlineShop.Domain.Models.Base;
using System.Collections.Generic;

namespace OnlineShop.Domain.Models
{
    public record Brand : OrderedEntity 
    {
        public int ProductsCount { get; init; }
        public ICollection<Product> Products { get; init; }
    }
}
