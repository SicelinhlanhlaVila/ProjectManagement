using Microsoft.EntityFrameworkCore;
using ProjectManagement.API.Data;
using ProjectManagement.API.Models;

namespace ProjectManagement.API.Services
{
    public class SkillService : ISkillService
    {
        private readonly AppDbContext _db;

        public SkillService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Skill>> GetAll()
        {
            var skills = await _db.Skills.AsNoTracking().ToListAsync();
            return skills;
        }
    }
}
