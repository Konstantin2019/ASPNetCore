﻿using OnlineShop.Domain.Models;
using System.Collections.Generic;

namespace OnlineShop.Data
{
    public static class EmployeesData
    {
        public static List<Employee> EmployeesList { get; } = new()
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
    }
}
