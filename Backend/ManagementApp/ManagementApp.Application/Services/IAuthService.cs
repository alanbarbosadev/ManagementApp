using ManagementApp.Application.Features.Auth.Commands.Register;
using ManagementApp.Application.Features.Auth.Queries.Login;
using ManagementApp.Application.Helpers;

namespace ManagementApp.Application.Services
{
    public interface IAuthService
    {
        Task<Result<RegisterResponse>> Register(RegisterRequest registerRequest);
        Task<Result<LoginResponse>> Login(LoginRequest authRequest);
    }
}
