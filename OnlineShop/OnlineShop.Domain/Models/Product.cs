using OnlineShop.Domain.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Domain.Models
{
    public class Product : OrderedEntity
    {
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        public int? BrandId { get; set; }

        [ForeignKey(nameof(BrandId))]
        public Brand Brand { get; set; }

        public string ImageUrl { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
    }
}
