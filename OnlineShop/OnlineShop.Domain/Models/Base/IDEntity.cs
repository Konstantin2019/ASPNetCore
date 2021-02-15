using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain.Models.Base
{
    public record IDEntity
    {
        [Key]
        public int Id { get; init; }
    }
}
