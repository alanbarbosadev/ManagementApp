using ManagementApp.Application.Helpers;
using ManagementApp.Application.Shared.Dtos.Positions;
using MediatR;

namespace ManagementApp.Application.Features.Positions.Commands.CreatePosition
{
    public record CreatePositionCommand(CreatePositionDto positionDto) : IRequest<Result<Unit>>;
}
