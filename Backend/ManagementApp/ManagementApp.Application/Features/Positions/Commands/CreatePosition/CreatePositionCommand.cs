using MediatR;

namespace ManagementApp.Application.Features.Positions.Commands.CreatePosition
{
    public record CreatePositionCommand(string Name) : IRequest<Unit>;
}
