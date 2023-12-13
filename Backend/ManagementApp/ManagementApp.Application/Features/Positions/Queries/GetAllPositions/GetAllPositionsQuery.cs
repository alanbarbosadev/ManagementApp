using ManagementApp.Application.Shared.Dtos;
using MediatR;

namespace ManagementApp.Application.Features.Positions.Queries.GetAllPositions
{
    public record GetAllPositionsQuery : IRequest<IReadOnlyList<PositionDto>>;
}
