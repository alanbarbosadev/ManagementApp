using System.ComponentModel.DataAnnotations;

namespace ManagementApp.Application.Models
{
    public class RegisterRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string DisplayName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[#$^+=!*()@%&]).{6,}$", ErrorMessage = "Password must have at least 6 characters, 1 uppercase, 1 lowercase, 1 number and 1 non-alphanumeric value.")]
        public string Password { get; set; }
    }
}
