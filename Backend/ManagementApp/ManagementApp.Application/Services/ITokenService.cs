using ManagementApp.Application.Models;
using ManagementApp.Domain.Models.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace ManagementApp.Application.Services
{
    public interface ITokenService
    {
        Task<JwtSecurityToken> GenerateToken(AppUser user, JwtSettings jwtSettings);
    }
}
