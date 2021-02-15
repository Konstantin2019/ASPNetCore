using OnlineShop.Domain.Models;
using OnlineShop.ViewModels;

namespace OnlineShop.Services.Extensions
{
    public static class EmployeesExtention
    {
        public static EmployeeViewModel ToView(this Employee employee)
        {
            if (employee is null) return null;

            return new EmployeeViewModel
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                SurName = employee.SurName,
                Patronymic = employee.Patronymic,
                Age = employee.Age,
                Address = employee.Address,
                Email = employee.Email
            };
        }

        public static Employee FromView(this EmployeeViewModel view)
        {
            if (view is null) return null;

            return new Employee
            {
                Id = view.Id,
                FirstName = view.FirstName,
                SurName = view.SurName,
                Patronymic = view.Patronymic,
                Age = view.Age,
                Address = view.Address,
                Email = view.Email
            };
        }
    }
}
