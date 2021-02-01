using OnlineShop.Domain.Models;
using System.Collections.Generic;

namespace OnlineShop.Services.Interfaces
{
    public interface IEmployeeSevice
    {
        IEnumerable<Employee> GetAll();
        Employee Get(int id);
        int Create(Employee employee);
        bool Update(Employee employee);
        bool Delete(int id);
    }
}
