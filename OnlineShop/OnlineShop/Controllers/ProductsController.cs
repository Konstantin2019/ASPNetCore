﻿using Microsoft.AspNetCore.Mvc;
using OnlineShop.Domain.Models;
using OnlineShop.Services.Extensions;
using OnlineShop.Services.Interfaces;
using OnlineShop.ViewModels;
using System.Linq;

namespace OnlineShop.Controllers
{
    public class ProductsController : Controller
    {
        private IProductService productService;
        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }
        public IActionResult Index(int? brandId, int? categoryId)
        {
            var filter = new ProductFilter
            {
                BrandId = brandId,
                CategoryId = categoryId
            };
            var products = productService.GetProducts(filter);
            return View(new CatalogViewModel
            {
                CategoryId = categoryId,
                BrandId = brandId,
                Products = products.OrderBy(p => p.Order).Select(p => p.ToView())
            });
        }
        public IActionResult Details(int id)
        {
            var product = productService.GetProductById(id);
            return View(product.ToView());
        }
        public IActionResult Checkout() => View("Checkout");
        public IActionResult Cart() => View("Cart");
        public IActionResult Login() => View("Login");
    }
}
