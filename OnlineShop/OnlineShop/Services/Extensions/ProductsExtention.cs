using OnlineShop.Domain.Models;
using OnlineShop.ViewModels;

namespace OnlineShop.Services.Extensions
{
    public static class ProductsExtention
    {
        public static ProductViewModel ToView(this Product product) 
        {
            if (product is null) return null;

            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Order = product.Order,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                Brand = product.Brand
            };
        }

        public static Product FromView(this ProductViewModel view)
        {
            if (view is null) return null;

            return new Product
            {
                Id = view.Id,
                Name = view.Name,
                Order = view.Order,
                ImageUrl = view.ImageUrl,
                Price = view.Price,
                Brand = view.Brand
            };
        }
    }
}
