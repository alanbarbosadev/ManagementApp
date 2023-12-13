using AutoMapper;
using ManagementApp.Application.Helpers;
using ManagementApp.Application.Repositories;
using ManagementApp.Domain.Models;
using MediatR;

namespace ManagementApp.Application.Features.Positions.Commands.CreatePosition
{
    public class CreatePositionCommandHandler : IRequestHandler<CreatePositionCommand, Result<Unit>>
    {
        private readonly IRepository<Position> _positionRepository;
        private readonly IMapper _mapper;

        public CreatePositionCommandHandler(IRepository<Position> positionRepository, IMapper mapper)
        {
            _positionRepository = positionRepository;
            _mapper = mapper;
        }

        public async Task<Result<Unit>> Handle(CreatePositionCommand request, CancellationToken cancellationToken)
        {
            var position = _mapper.Map<Position>(request.positionDto);

            _positionRepository.AddAsync(position);

            var hasChanges = await _positionRepository.SaveChangesAsync();

            if (hasChanges)
            {
                return Result<Unit>.Success(Unit.Value);
            }

            return Result<Unit>.Failed("Failed to insert a new position");
        }
    }
}
