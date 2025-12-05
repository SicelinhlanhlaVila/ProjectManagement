using ProjectManagement.API.Models;

namespace ProjectManagement.API.Services
{
    public interface IProfileService
    {
        Task<Profile> GetProfile();
    }
}
