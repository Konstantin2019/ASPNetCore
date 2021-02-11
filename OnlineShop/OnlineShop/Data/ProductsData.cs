using OnlineShop.Domain.Models;
using System.Collections.Generic;

namespace OnlineShop.Data
{
    public static class ProductsData
    {
        public static List<Product> products = new() 
        {
            new Product()
            {
                Id = 1,
                Name = "Easy Polo Black Edition",
                Price = 1025,
                ImageUrl = "product1.jpg",
                Order = 0,
                CategoryId = 2,
                BrandId = 1
            },
            new Product()
            {
                Id = 2,
                Name = "Easy Polo Black Edition",
                Price = 1025,
                ImageUrl = "product2.jpg",
                Order = 1,
                CategoryId = 2,
                BrandId = 1
            },
            new Product()
            {
                Id = 3,
                Name = "Easy Polo Black Edition",
                Price = 1025,
                ImageUrl = "product3.jpg",
                Order = 2,
                CategoryId = 2,
                BrandId = 1
            },
            new Product()
            {
                Id = 4,
                Name = "Easy Polo Black Edition",
                Price = 1025,
                ImageUrl = "product4.jpg",
                Order = 3,
                CategoryId = 2,
                BrandId = 1
            },
            new Product()
            {
                Id = 5,
                Name = "Easy Polo Black Edition",
                Price = 1025,
                ImageUrl = "product5.jpg",
                Order = 4,
                CategoryId = 2,
                BrandId = 2
            },
            new Product()
            {
                Id = 6,
                Name = "Easy Polo Black Edition",
                Price = 1025,
                ImageUrl = "product6.jpg",
                Order = 5,
                CategoryId = 2,
                BrandId = 2
            },
            new Product()
            {
                Id = 7,
                Name = "Easy Polo Black Edition",
                Price = 1025,
                ImageUrl = "product7.jpg",
                Order = 6,
                CategoryId = 2,
                BrandId = 2
            },
            new Product()
            {
                Id = 8,
                Name = "Easy Polo Black Edition",
                Price = 1025,
                ImageUrl = "product8.jpg",
                Order = 7,
                CategoryId = 25,
                BrandId = 2
            },
            new Product()
            {
                Id = 9,
                Name = "Easy Polo Black Edition",
                Price = 1025,
                ImageUrl = "product9.jpg",
                Order = 8,
                CategoryId = 25,
                BrandId = 2
            },
            new Product()
            {
                Id = 10,
                Name = "Easy Polo Black Edition",
                Price = 1025,
                ImageUrl = "product10.jpg",
                Order = 9,
                CategoryId = 25,
                BrandId = 3
            },
            new Product()
            {
                Id = 11,
                Name = "Easy Polo Black Edition",
                Price = 1025,
                ImageUrl = "product11.jpg",
                Order = 10,
                CategoryId = 25,
                BrandId = 3
            },
            new Product()
            {
                Id = 12,
                Name = "Easy Polo Black Edition",
                Price = 1025,
                ImageUrl = "product12.jpg",
                Order = 11,
                CategoryId = 25,
                BrandId = 3
            }
        };
    }
}
