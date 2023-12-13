using MediatR;

namespace ManagementApp.Application.Features.Auth.Queries.Login
{
    public record LoginQuery(LoginRequest loginRequest) : IRequest<LoginResponse>;
}
