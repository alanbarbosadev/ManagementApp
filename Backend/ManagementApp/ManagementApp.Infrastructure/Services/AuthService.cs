using ManagementApp.Application.Models;
using ManagementApp.Application.Services;
using ManagementApp.Domain.Exceptions;
using ManagementApp.Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ManagementApp.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly JwtSettings _jwtSettings;

        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService, IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<AuthResponse> Login(AuthRequest authRequest)
        {
            var appUser = await _userManager.FindByEmailAsync(authRequest.Email);

            if (appUser == null)
            {
                throw new NotFoundException("User not found!");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(appUser, authRequest.Password, false);

            if (!result.Succeeded)
            {
                throw new InvalidCredentialsException("Invalid Credentials!");
            }

            JwtSecurityToken jwtSecurityToken = await _tokenService.GenerateToken(appUser, _jwtSettings);

            return new AuthResponse()
            {
                Id = appUser.Id,
                UserName = appUser.UserName,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)
            };
        }

        public async Task<RegisterResponse> Register(RegisterRequest registerRequest)
        {
            var appUser = new AppUser()
            {
                UserName = registerRequest.UserName,
                DisplayName = registerRequest.DisplayName,
                Email = registerRequest.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(appUser, registerRequest.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(appUser, "User");

                JwtSecurityToken jwtSecurityToken = await _tokenService.GenerateToken(appUser, _jwtSettings);

                return new RegisterResponse()
                {
                    Id = appUser.Id,
                    UserName = appUser.UserName,
                    Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)
                };
            }
            else
            {
                var errorResponse = new StringBuilder();

                foreach(var error in result.Errors)
                {
                    errorResponse.AppendLine(error.Description);
                }

                throw new Exception(errorResponse.ToString());
            }
        }
    }
}
