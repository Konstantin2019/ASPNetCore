using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; init; }
        public string FirstName { get; init; }
        public string SurName { get; init; }
        public string Patronymic { get; init; }
        public byte Age { get; init; }
        public string Address { get; init; }
        public string Email { get; init; }
    }
}
