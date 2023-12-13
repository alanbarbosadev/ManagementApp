using ManagementApp.Api.Errors;
using ManagementApp.Application.Features.Auth.Commands.Register;
using ManagementApp.Application.Features.Auth.Queries.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ManagementApp.Api.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest loginRequest)
        {
            return Ok(await _mediator.Send(new LoginQuery(loginRequest)));
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiValidationErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RegisterResponse>> Register(RegisterRequest registerRequest)
        {
            return Ok(await _mediator.Send(new RegisterCommand(registerRequest)));
        }

        //[HttpGet("currentUser")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(typeof(TokenExpiredException), StatusCodes.Status401Unauthorized)]
        //public async Task<ActionResult<UserViewModel>> GetCurrentUser()
        //{
        //    var user = await _userService.GetCurrentUser();

        //    return Ok(_mapper.Map<UserViewModel>(user));
        //}
    }
}
