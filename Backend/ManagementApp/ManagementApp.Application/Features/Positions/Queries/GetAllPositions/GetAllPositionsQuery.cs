using ManagementApp.Application.Helpers;
using ManagementApp.Application.Shared.Dtos.Positions;
using MediatR;

namespace ManagementApp.Application.Features.Positions.Queries.GetAllPositions
{
    public record GetAllPositionsQuery : IRequest<Result<IReadOnlyList<PositionDto>>>;
}
