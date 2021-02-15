﻿using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain.Models.Base
{
    public record NamedEntity : IDEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
