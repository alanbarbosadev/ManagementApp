using ManagementApp.Application.Helpers;
using MediatR;

namespace ManagementApp.Application.Features.Auth.Queries.Login
{
    public record LoginQuery(LoginRequest loginRequest) : IRequest<Result<LoginResponse>>;
}
