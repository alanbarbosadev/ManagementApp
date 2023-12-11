using Microsoft.AspNetCore.Identity;

namespace ManagementApp.Domain.Models.Identity
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
    }
}
