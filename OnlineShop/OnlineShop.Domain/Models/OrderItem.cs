using OnlineShop.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Domain.Models
{
    public class OrderItem : IDEntity
    {
        [Required]
        public Order Order { get; init; }

        [Required]
        public Product Product { get; init; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; init; }

        public int Quantity { get; init; }

        [NotMapped]
        public decimal TotalPrice => Price * Quantity;
    }
}
