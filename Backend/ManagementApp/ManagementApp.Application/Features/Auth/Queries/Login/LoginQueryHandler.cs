using ManagementApp.Application.Helpers;
using ManagementApp.Application.Services;
using MediatR;

namespace ManagementApp.Application.Features.Auth.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, Result<LoginResponse>>
    {
        private readonly IAuthService _authService;

        public LoginQueryHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<Result<LoginResponse>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            return await _authService.Login(request.loginRequest);
        }
    }
}
