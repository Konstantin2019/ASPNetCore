using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; init; }

        #region FirstName
        [Required(AllowEmptyStrings = false,
                  ErrorMessage = "Name is required field")]
        [Display(Name = "Name")]
        [StringLength(maximumLength: 50, MinimumLength = 2,
                      ErrorMessage = "Name length should be at least 2 symbols and less then 50")]
        [RegularExpression(@"([А-ЯЁ][а-яё]+)|([A-Z][a-z]+)", 
                           ErrorMessage = "FirstName invalid format")]
        public string FirstName { get; init; }
        #endregion

        #region SurName
        [Required(AllowEmptyStrings = false,
                  ErrorMessage = "SurName is required field")]
        [Display(Name = "Surname")]
        [RegularExpression(@"([А-ЯЁ][а-яё]+)|([A-Z][a-z]+)", 
                           ErrorMessage = "SurName invalid format")]
        public string SurName { get; init; }
        #endregion

        #region Patronimyc
        [Display(Name = "Patronymic")]
        public string Patronymic { get; init; }
        #endregion

        #region Age
        [Range(18, 80, ErrorMessage = "Employee must have age in range 18-80")]
        [Display(Name = "Age")]
        public byte Age { get; init; }
        #endregion

        #region Address
        [Display(Name = "Address")]
        public string Address { get; init; }
        #endregion

        #region Email
        [Display(Name = "Email")]
        public string Email { get; init; }
        #endregion
    }
}
