using MediatR;

namespace ManagementApp.Application.Features.Auth.Commands.Register
{
    public record RegisterCommand(RegisterRequest registerRequest) : IRequest<RegisterResponse>;
}
