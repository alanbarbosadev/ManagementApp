using ManagementApp.Api.Errors;
using ManagementApp.Application.Features.Positions.Commands.CreatePosition;
using ManagementApp.Application.Features.Positions.Queries.GetAllPositions;
using ManagementApp.Application.Shared.Dtos.Positions;
using Microsoft.AspNetCore.Mvc;

namespace ManagementApp.Api.Controllers
{
    public class PositionController : BaseApiController
    {
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPositions()
        {
            return HandleResult(await Mediator.Send(new GetAllPositionsQuery()));
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiValidationErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreatePosition([FromBody] CreatePositionDto positionDto)
        {
            return HandleResult(await Mediator.Send(new CreatePositionCommand(positionDto)));
        }
    }
}
