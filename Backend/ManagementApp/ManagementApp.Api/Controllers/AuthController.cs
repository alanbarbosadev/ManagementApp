using AutoMapper;
using ManagementApp.Api.Errors;
using ManagementApp.Api.ViewModels;
using ManagementApp.Application.Models;
using ManagementApp.Application.Services;
using ManagementApp.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace ManagementApp.Api.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AuthController(IAuthService authService, IUserService userService, IMapper mapper)
        {
            _authService = authService;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest authRequest)
        {
            return Ok(await _authService.Login(authRequest));
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiValidationErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RegisterResponse>> Register(RegisterRequest registerRequest)
        {
            return Ok(await _authService.Register(registerRequest));
        }

        [HttpGet("currentUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(TokenExpiredException), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<UserViewModel>> GetCurrentUser()
        {
            var user = await _userService.GetCurrentUser();

            return Ok(_mapper.Map<UserViewModel>(user));
        }
    }
}
