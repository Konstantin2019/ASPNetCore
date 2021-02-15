using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Domain.Models;
using OnlineShop.Domain.Models.Identity;
using OnlineShop.Services.Extensions;
using OnlineShop.Services.Interfaces;
using OnlineShop.ViewModels;
using System;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = Role.administrator)]
    public class ProductsController : Controller
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }
        public IActionResult Index()
        {
            var products = productService.GetProducts(new ProductFilter());
            return View(products);
        }

        #region Update
        [Authorize(Roles = Role.administrator)]
        public IActionResult Update(int id)
        {
            if (id < 0)
                return BadRequest();
            var product = productService.GetProductById(id);
            if (product is null)
                product = new Product();
            if (product is null) return NotFound();
            return View(product.ToView());
        }

        [HttpPost]
        [Authorize(Roles = Role.administrator)]
        public IActionResult Update(ProductViewModel model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(ProductViewModel));
            if (!ModelState.IsValid) return View(model);
            var product = model.FromView();
            if (model.Id == 0)
                productService.Add(product);
            else
                productService.Update(product);
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
        [Authorize(Roles = Role.administrator)]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest();
            var product = productService.GetProductById(id);
            if (product is null) return NotFound();
            return View(product.ToView());
        }

        [HttpPost]
        [Authorize(Roles = Role.administrator)]
        public IActionResult DeleteConfirmed(int id)
        {
            productService.Delete(id);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
