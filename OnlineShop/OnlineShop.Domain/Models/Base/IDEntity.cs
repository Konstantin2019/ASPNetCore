using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain.Models.Base
{
    public class IDEntity
    {
        [Key]
        public int Id { get; init; }
    }
}
