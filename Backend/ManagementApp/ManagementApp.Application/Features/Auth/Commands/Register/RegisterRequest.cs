namespace ManagementApp.Application.Features.Auth.Commands.Register
{
    public class RegisterRequest
    {
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
