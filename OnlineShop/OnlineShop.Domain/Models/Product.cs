using OnlineShop.Domain.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Domain.Models
{
    public record Product : OrderedEntity
    {
        public int CategoryId { get; init; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; init; }

        public int? BrandId { get; init; }

        [ForeignKey(nameof(BrandId))]
        public Brand Brand { get; set; }

        public string ImageUrl { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
    }
}
