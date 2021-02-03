using Microsoft.AspNetCore.Identity;

namespace OnlineShop.Domain.Models
{
    public class Role : IdentityRole
    {
        public const string administrator = "Administrators";
        public const string users = "Users";

        public string Description { get; set; }
    }
}
