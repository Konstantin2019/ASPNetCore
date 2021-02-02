using OnlineShop.Data;
using OnlineShop.Domain.Models;
using OnlineShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.InMemory.Services
{
    public class InMemoryEmployeeService : IEmployeeSevice
    {
        private readonly List<Employee> employees;
        private int currentMaxId;
        public InMemoryEmployeeService()
        {
            employees = EmployeesData.EmployeesList;
            currentMaxId = employees.DefaultIfEmpty().Max(e => e?.Id ?? 1);
        }
        public Employee Get(int id) => employees.FirstOrDefault(e => e.Id == id);
        public IEnumerable<Employee> GetAll() => employees;
        public int Create(Employee employee)
        {
            if (employee is null)
                throw new ArgumentNullException(nameof(Employee));
            if (employees.Contains(employee))
                return employee.Id;
            employee.Id = currentMaxId + 1;
            employees.Add(employee);
            return employee.Id;
        }
        public bool Update(Employee employee)
        {
            if (employee is null)
                throw new ArgumentNullException(nameof(Employee));
            if (employees.Contains(employee))
                return true;
            var item = Get(employee.Id);
            if (item is null)
                return false;
            item.FirstName = employee.FirstName;
            item.SurName = employee.SurName;
            item.Patronymic = employee.Patronymic;
            item.Age = employee.Age;
            item.Address = employee.Address;
            item.Email = employee.Email;
            return true;
        }
        public bool Delete(int id)
        {
            var item = Get(id);
            if (item is null)
                return false;
            employees.Remove(item);
            return true;
        }
    }
}
