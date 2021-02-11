using OnlineShop.Domain.Models;
using System.Collections.Generic;

namespace OnlineShop.Data
{
    public class BrandsData
    {
        public static List<Brand> brands = new()
        {
            new Brand()
            {
                Id = 1,
                Name = "Acne",
                Order = 0
            },
            new Brand()
            {
                Id = 2,
                Name = "Grüne Erde",
                Order = 1
            },
            new Brand()
            {
                Id = 3,
                Name = "Albiro",
                Order = 2
            },
            new Brand()
            {
                Id = 4,
                Name = "Ronhill",
                Order = 3
            },
            new Brand()
            {
                Id = 5,
                Name = "Oddmolly",
                Order = 4
            },
            new Brand()
            {
                Id = 6,
                Name = "Boudestijn",
                Order = 5
            },
            new Brand()
            {
                Id = 7,
                Name = "Rösch creative culture",
                Order = 6
            },
        };
    }
}
