using ManagementApp.Application.Helpers;
using ManagementApp.Application.Services;
using MediatR;

namespace ManagementApp.Application.Features.Auth.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<RegisterResponse>>
    {
        private readonly IAuthService _authService;

        public RegisterCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<Result<RegisterResponse>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            return await _authService.Register(request.registerRequest);
        }
    }
}
