using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly List<Employee> employees;

        public EmployeesController()
        {
            employees = EmployeesData.EmployeesList;
        }
        public IActionResult Index() => View(employees);
        public IActionResult Details(int id) 
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            return View(employee);
        } 
    }
}
