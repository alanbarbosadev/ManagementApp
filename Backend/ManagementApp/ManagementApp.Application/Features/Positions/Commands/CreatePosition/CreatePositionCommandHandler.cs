using AutoMapper;
using ManagementApp.Application.Repositories;
using ManagementApp.Domain.Models;
using MediatR;

namespace ManagementApp.Application.Features.Positions.Commands.CreatePosition
{
    public class CreatePositionCommandHandler : IRequestHandler<CreatePositionCommand, Unit>
    {
        private readonly IRepository<Position> _positionRepository;
        private readonly IMapper _mapper;

        public CreatePositionCommandHandler(IRepository<Position> positionRepository, IMapper mapper)
        {
            _positionRepository = positionRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreatePositionCommand request, CancellationToken cancellationToken)
        {
            var position = _mapper.Map<Position>(request);

            await _positionRepository.AddAsync(position);

            return Unit.Value;
        }
    }
}
