using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models.Base
{
    public class NamedEntity : IDEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
