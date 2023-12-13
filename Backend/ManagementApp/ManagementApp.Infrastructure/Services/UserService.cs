using ManagementApp.Application.Services;
using ManagementApp.Domain.Exceptions;
using ManagementApp.Domain.Models.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ManagementApp.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<AppUser> GetCurrentUser()
        {
            var email = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;

            var user = await _userManager.FindByEmailAsync(email);

            return user;
        }

        public async Task CheckUserToken()
        {
            var token = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");

            var tokenValidTo = new JwtSecurityTokenHandler().ReadJwtToken(token).ValidTo;

            if (tokenValidTo < DateTime.UtcNow)
            {
                throw new TokenExpiredException("Token expired!");
            }
        }
    }
}
