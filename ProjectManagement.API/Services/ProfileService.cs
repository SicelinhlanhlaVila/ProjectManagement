using Microsoft.EntityFrameworkCore;
using ProjectManagement.API.Data;
using ProjectManagement.API.Models;

namespace ProjectManagement.API.Services
{
    public class ProfileService : IProfileService
    {
        private readonly AppDbContext _db;

        public ProfileService(AppDbContext dbContext) => _db = dbContext;

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
