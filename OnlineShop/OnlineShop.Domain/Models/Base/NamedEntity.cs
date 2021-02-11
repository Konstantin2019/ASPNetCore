using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain.Models.Base
{
    public class NamedEntity : IDEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
