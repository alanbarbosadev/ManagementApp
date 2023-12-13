using AutoMapper;
using ManagementApp.Application.Repositories;
using ManagementApp.Application.Shared.Dtos;
using ManagementApp.Domain.Models;
using MediatR;

namespace ManagementApp.Application.Features.Positions.Queries.GetAllPositions
{
    public class GetAllPositionsQueryHandler : IRequestHandler<GetAllPositionsQuery, IReadOnlyList<PositionDto>>
    {
        private readonly IRepository<Position> _positionRepository;
        private readonly IMapper _mapper;

        public GetAllPositionsQueryHandler(IRepository<Position> positionRepository, IMapper mapper)
        {
            _positionRepository = positionRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<PositionDto>> Handle(GetAllPositionsQuery request, CancellationToken cancellationToken)
        {
            var positions = _mapper.Map<IReadOnlyList<PositionDto>>(await _positionRepository.GetAllAsync());

            return positions;
        }
    }
}
