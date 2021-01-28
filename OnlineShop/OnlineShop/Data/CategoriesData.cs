using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Data
{
    public static class CategoriesData
    {
        public static List<Category> categories = new()
        {
            new Category()
            {
                Id = 1,
                Name = "Sportswear",
                Order = 0,
                ParentId = null
            },
            new Category()
            {
                Id = 2,
                Name = "Nike",
                Order = 0,
                ParentId = 1
            },
            new Category()
            {
                Id = 3,
                Name = "Under Armour",
                Order = 1,
                ParentId = 1
            },
            new Category()
            {
                Id = 4,
                Name = "Adidas",
                Order = 2,
                ParentId = 1
            },
            new Category()
            {
                Id = 5,
                Name = "Puma",
                Order = 3,
                ParentId = 1
            },
            new Category()
            {
                Id = 6,
                Name = "ASICS",
                Order = 4,
                ParentId = 1
            },
            new Category()
            {
                Id = 7,
                Name = "Mens",
                Order = 1,
                ParentId = null
            },
            new Category()
            {
                Id = 8,
                Name = "Fendi",
                Order = 0,
                ParentId = 7
            },
            new Category()
            {
                Id = 9,
                Name = "Guess",
                Order = 1,
                ParentId = 7
            },
            new Category()
            {
                Id = 10,
                Name = "Valentino",
                Order = 2,
                ParentId = 7
            },
            new Category()
            {
                Id = 11,
                Name = "Dior",
                Order = 3,
                ParentId = 7
            },
            new Category()
            {
                Id = 12,
                Name = "Versace",
                Order = 4,
                ParentId = 7
            },
            new Category()
            {
                Id = 13,
                Name = "Armani",
                Order = 5,
                ParentId = 7
            },
            new Category()
            {
                Id = 14,
                Name = "Prada",
                Order = 6,
                ParentId = 7
            },
            new Category()
            {
                Id = 15,
                Name = "Dolce and Gabbana",
                Order = 7,
                ParentId = 7
            },
            new Category()
            {
                Id = 16,
                Name = "Chanel",
                Order = 8,
                ParentId = 7
            },
            new Category()
            {
                Id = 17,
                Name = "Gucci",
                Order = 1,
                ParentId = 7
            },
            new Category()
            {
                Id = 18,
                Name = "Womens",
                Order = 2,
                ParentId = null
            },
            new Category()
            {
                Id = 19,
                Name = "Fendi",
                Order = 0,
                ParentId = 18
            },
            new Category()
            {
                Id = 20,
                Name = "Guess",
                Order = 1,
                ParentId = 18
            },
            new Category()
            {
                Id = 21,
                Name = "Valentino",
                Order = 2,
                ParentId = 18
            },
            new Category()
            {
                Id = 22,
                Name = "Dior",
                Order = 3,
                ParentId = 18
            },
            new Category()
            {
                Id = 23,
                Name = "Versace",
                Order = 4,
                ParentId = 18
            },
            new Category()
            {
                Id = 24,
                Name = "Kids",
                Order = 3,
                ParentId = null
            },
            new Category()
            {
                Id = 25,
                Name = "Fashion",
                Order = 4,
                ParentId = null
            },
            new Category()
            {
                Id = 26,
                Name = "Households",
                Order = 5,
                ParentId = null
            },
            new Category()
            {
                Id = 27,
                Name = "Interiors",
                Order = 6,
                ParentId = null
            },
            new Category()
            {
                Id = 28,
                Name = "Clothing",
                Order = 7,
                ParentId = null
            },
            new Category()
            {
                Id = 29,
                Name = "Bags",
                Order = 8,
                ParentId = null
            },
            new Category()
            {
                Id = 30,
                Name = "Shoes",
                Order = 9,
                ParentId = null
            }
        };
    }
}
