using ManagementApp.Application.Features.Auth.Commands.Register;
using ManagementApp.Application.Features.Auth.Queries.Login;

namespace ManagementApp.Application.Services
{
    public interface IAuthService
    {
        Task<RegisterResponse> Register(RegisterRequest registerRequest);
        Task<LoginResponse> Login(LoginRequest authRequest);
    }
}
