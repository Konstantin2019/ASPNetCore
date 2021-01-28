using Microsoft.AspNetCore.Mvc;
using OnlineShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        private IProductService productService;
        public CategoriesViewComponent(IProductService productService)
        {
            this.productService = productService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await GetCategories();
            return View(categories);
        }

        private Task<List<CategoryViewModel>> GetCategories()
        {
            var task = Task.Run(() =>
            {
                var categories = productService.GetCategories();
                var parentCategories = categories.Where(c => c.ParentId is null).ToList();
                var parents = new List<CategoryViewModel>();
                foreach (var parent in parentCategories)
                {
                    parents.Add(new CategoryViewModel
                    {
                        Id = parent.Id,
                        Name = parent.Name,
                        Order = parent.Order,
                        ParentCategory = null
                    });
                }
                foreach (var parent in parents)
                {
                    var childCategories = categories.Where(c => c.ParentId == parent.Id);
                    foreach (var childCategory in childCategories)
                    {
                        parent.ChildSections.Add(new CategoryViewModel()
                        {
                            Id = childCategory.Id,
                            Name = childCategory.Name,
                            Order = childCategory.Order,
                            ParentCategory = parent
                        });
                    }
                    parent.ChildSections = parent.ChildSections.OrderBy(c => c.Order).ToList();
                }
                parents.OrderBy(c => c.Order).ToList();
                return parents;
            });
            return task;
        }
    }
}
