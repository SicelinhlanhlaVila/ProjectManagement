using Microsoft.EntityFrameworkCore;
using ProjectManagement.API.Data;
using ProjectManagement.API.Models;

namespace ProjectManagement.API.Services
{
    /// <summary>
    /// provides operations to handle all Profile related logic
    /// </summary>
    public class ProfileService : IProfileService
    {
        private readonly AppDbContext _db;

        /// <summary>
        /// Initialises the constructor
        /// </summary>
        /// <param name="dbContext"></param>
        public ProfileService(AppDbContext dbContext) => _db = dbContext;

        /// <summary>
        /// getsa specific profile
        /// </summary>
        /// <returns></returns>
        public async Task<Profile> GetProfile()
        {
            var profile = await _db.Profiles.AsNoTracking().FirstOrDefaultAsync();
            if (profile == null) {
                return new Profile();
            }
            return profile;
        }
    }
}
