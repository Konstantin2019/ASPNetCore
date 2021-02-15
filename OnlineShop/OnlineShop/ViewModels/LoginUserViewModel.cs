using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.ViewModels
{
    public record LoginUserViewModel
    {
        [Required, MaxLength(256)]
        public string UserName { get; init; }

        [Required, DataType(DataType.Password)]
        public string Password { get; init; }

        [Display(Name = nameof(RememberMe))]
        public bool RememberMe { get; init; }
        
        [HiddenInput(DisplayValue = false)]
        public string ReturnUrl { get; init; }
    }
}
