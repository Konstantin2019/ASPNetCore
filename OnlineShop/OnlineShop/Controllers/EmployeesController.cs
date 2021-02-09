using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using OnlineShop.Domain.Models;
using OnlineShop.Services.Interfaces;
using OnlineShop.ViewModels;
using System;
using OnlineShop.Domain.Models.Identity;

namespace OnlineShop.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeSevice employeeSevice;
        public EmployeesController(IEmployeeSevice employeeSevice)
        {
            this.employeeSevice = employeeSevice;
        }
        public IActionResult Index() => View(employeeSevice.GetAll());
        public IActionResult Details(int id) => View(employeeSevice.Get(id));
        #region Update
        [Authorize(Roles = Role.administrator)]
        public IActionResult Update(int id)
        {
            if (id < 0)
                return BadRequest();
            var employee = employeeSevice.Get(id);
            if (employee is null)
                employee = new Employee();
            return View(new EmployeeViewModel
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                SurName = employee.SurName,
                Patronymic = employee.Patronymic,
                Age = employee.Age,
                Address = employee.Address,
                Email = employee.Email
            });
        }
        [Authorize(Roles = Role.administrator)]
        [HttpPost]
        public IActionResult Update(EmployeeViewModel model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(EmployeeViewModel));
            if (!ModelState.IsValid) return View(model);
            var employee = new Employee
            {
                Id = model.Id,
                FirstName = model.FirstName,
                SurName = model.SurName,
                Patronymic = model.Patronymic,
                Age = model.Age,
                Address = model.Address,
                Email = model.Email
            };
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
            return View(new EmployeeViewModel
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                SurName = employee.SurName,
                Patronymic = employee.Patronymic,
                Age = employee.Age,
                Address = employee.Address,
                Email = employee.Email
            });
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
