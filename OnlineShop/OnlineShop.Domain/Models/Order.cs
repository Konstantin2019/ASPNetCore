using OnlineShop.Domain.Models.Base;
using OnlineShop.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Domain.Models
{
    public record Order : NamedEntity
    {
        [Required]
        public User User { get; init; }

        [Required]
        public string Phone { get; init; }

        [Required]
        public string Address { get; init; }

        public DateTime Date { get; set; } = DateTime.Now;

        public ICollection<OrderItem> Items { get; set; } = new HashSet<OrderItem>();

    }
}
