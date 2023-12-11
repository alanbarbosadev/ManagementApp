using AutoMapper;
using ManagementApp.Api.ViewModels.Position;
using ManagementApp.Application.Repositories;
using ManagementApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManagementApp.Api.Controllers
{
    public class PositionController : BaseApiController
    {
        private readonly IRepository<Position> _positionRepository;
        private readonly IMapper _mapper;

        public PositionController(IRepository<Position> positionRepository, IMapper mapper)
        {
            _positionRepository = positionRepository;
            _mapper = mapper; 
        }

        [HttpGet()]
        public async Task<ActionResult<IReadOnlyList<Position>>> GetAllPositions()
        {
            return Ok(_mapper.Map<IReadOnlyList<PositionViewModel>>(await _positionRepository.GetAllAsync()));
        }

        [HttpPost("create")]
        public async Task<ActionResult<PositionViewModel>> CreatePosition(CreatePositionViewModel createPositionViewModel)
        {
            var position = _mapper.Map<Position>(createPositionViewModel);

            await _positionRepository.AddAsync(position);

            return Ok(_mapper.Map<PositionViewModel>(position));
        }
    }
}
