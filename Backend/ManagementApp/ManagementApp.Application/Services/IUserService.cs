using ManagementApp.Domain.Models.Identity;

namespace ManagementApp.Application.Services
{
    public interface IUserService
    {
        Task<AppUser> GetCurrentUser();
        Task CheckUserToken();
    }
}
