using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required, MaxLength(256)]
        public string UserName { get; init; }

        [Required, DataType(DataType.Password)]
        public string Password { get; init; }

        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; init; }
    }
}
