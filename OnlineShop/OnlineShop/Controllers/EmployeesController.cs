using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using OnlineShop.Domain.Models;
using OnlineShop.Services.Interfaces;
using OnlineShop.ViewModels;
using System;
using System.Linq;
using OnlineShop.Domain.Models.Identity;
using OnlineShop.Services.Extensions;

namespace OnlineShop.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeSevice employeeSevice;
        public EmployeesController(IEmployeeSevice employeeSevice)
        {
            this.employeeSevice = employeeSevice;
        }
        public IActionResult Index() => View(employeeSevice.GetAll().Select(e => e.ToView()));
        public IActionResult Details(int id) => View(employeeSevice.Get(id).ToView());
        #region Update
        [Authorize(Roles = Role.administrator)]
        public IActionResult Update(int id)
        {
            if (id < 0)
                return BadRequest();
            var employee = employeeSevice.Get(id);
            if (employee is null)
                employee = new Employee();
            return View(employee.ToView());
        }
        [Authorize(Roles = Role.administrator)]
        [HttpPost]
        public IActionResult Update(EmployeeViewModel model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(EmployeeViewModel));
            if (!ModelState.IsValid) return View(model);
            var employee = model.FromView();
            if (employee.Id == 0)
                employeeSevice.Create(employee);
            else
                employeeSevice.Update(employee);
            return RedirectToAction("Index");
        }
        #endregion
        #region Delete
        [Authorize(Roles = Role.administrator)]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest();
            var employee = employeeSevice.Get(id);
            if (employee is null)
                return NotFound();
            return View(employee.ToView());
        }
        [Authorize(Roles = Role.administrator)]
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            employeeSevice.Delete(id);
            return RedirectToAction("Index");
        }
        #endregion
    }
}
