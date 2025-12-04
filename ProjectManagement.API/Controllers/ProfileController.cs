using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.API.Data;
using ProjectManagement.API.Models;

namespace ProjectManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly AppDbContext _db;
        public ProfileController(AppDbContext db) => _db = db;

        [HttpGet]
        public async Task<ActionResult<Profile>> Get()
        {
            var profile = await _db.Profiles.AsNoTracking().FirstOrDefaultAsync();
            if (profile == null) return NotFound();
            return Ok(profile);
        }
    }
}

