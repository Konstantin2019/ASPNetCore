using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Services
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
