using ManagementApp.Application.Features.Positions.Commands.CreatePosition;
using ManagementApp.Application.Features.Positions.Queries.GetAllPositions;
using ManagementApp.Application.Shared.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ManagementApp.Api.Controllers
{
    public class PositionController : BaseApiController
    {
        private readonly IMediator _mediator;

        public PositionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<ActionResult<IReadOnlyList<PositionDto>>> GetAllPositions()
        {
            return Ok(await _mediator.Send(new GetAllPositionsQuery()));
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreatePosition(CreatePositionCommand createPositionCommand)
        {
            await _mediator.Send(createPositionCommand);

            return NoContent();
        }
    }
}
