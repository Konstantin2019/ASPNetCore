using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        private static readonly List<Employee> employees = new()
        {
            new Employee
            {
                Id = 1,
                FirstName = "Кирилл",
                SurName = "Комбаров",
                Patronymic = "Геннадьевич",
                Age = 29,
                Address = "Нет данных",
                Email = "kombarov@mail.ru"
            },
            new Employee
            {
                Id = 2,
                FirstName = "Геннадий",
                SurName = "Ветров",
                Patronymic = "Александрович",
                Age = 34,
                Address = "Нет данных",
                Email = "vetrov@yandex.ru"
            },
            new Employee
            {
                Id = 3,
                FirstName = "Игорь",
                SurName = "Сидихин",
                Patronymic = "Викторович",
                Age = 30,
                Address = "Нет данных",
                Email = "sidihin@rambler.ru"
            },
            new Employee
            {
                Id = 4,
                FirstName = "Максим",
                SurName = "Рыбин",
                Patronymic = "Альбертович",
                Age = 42,
                Address = "Нет данных",
                Email = "ribin@gmail.com"
            },
            new Employee
            {
                Id = 5,
                FirstName = "Валерий",
                SurName = "Никифоров",
                Patronymic = "Дмитриевич",
                Age = 54,
                Address = "Нет данных",
                Email = "nikiforov@rambler.ru"
            }
        };
        public IActionResult Index()
        {
            return View(employees);
        }
        public IActionResult SelectedEmployee(int id)
        {
            return View(employees[id - 1]);
        }
    }
}
