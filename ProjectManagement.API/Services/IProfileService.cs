using ProjectManagement.API.Models;

namespace ProjectManagement.API.Services
{
    /// <summary>
    /// provides operations to handle profile logic
    /// </summary>
    public interface IProfileService
    {
        /// <summary>
        /// gets a specific profile
        /// </summary>
        /// <returns></returns>
        Task<Profile> GetProfile();
    }
}
