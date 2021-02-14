using Microsoft.AspNetCore.Identity;

namespace OnlineShop.Domain.Models.Identity
{
    public class User : IdentityUser
    {
        public const string administrator = "admin";
        public const string defaultAdminPassword = "admin_password";

        public string Description { get; set; }
    }
}
