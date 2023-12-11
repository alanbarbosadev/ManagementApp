using ManagementApp.Application.Models;

namespace ManagementApp.Application.Services
{
    public interface IAuthService
    {
        Task<RegisterResponse> Register(RegisterRequest registerRequest);
        Task<AuthResponse> Login(AuthRequest authRequest);
    }
}
