using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.API.Data;
using ProjectManagement.API.Models;

namespace ProjectManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly AppDbContext _db;
        public SkillsController(AppDbContext db) => _db = db;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Skill>>> Get()
        {
            var skills = await _db.Skills.AsNoTracking().ToListAsync();
            return Ok(skills);
        }
    }
}
