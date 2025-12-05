using Microsoft.EntityFrameworkCore;
using ProjectManagement.API.Data;
using ProjectManagement.API.Models;

namespace ProjectManagement.API.Services
{
    /// <summary>
    /// Provides operations for all skill related logic
    /// </summary>
    public class SkillService : ISkillService
    {
        private readonly AppDbContext _db;

        /// <summary>
        /// Initialises the constructor
        /// </summary>
        /// <param name="db"></param>
        public SkillService(AppDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Gets all skills
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Skill>> GetAll()
        {
            var skills = await _db.Skills.AsNoTracking().ToListAsync();
            return skills;
        }
    }
}
