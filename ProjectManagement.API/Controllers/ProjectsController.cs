using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.API.Data;
using ProjectManagement.API.Models;

namespace ProjectManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ProjectsController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> Get()
        {
            var projects = await _db.Projects.AsNoTracking().ToListAsync();
            return Ok(projects);
        }

        [HttpPost]
        public async Task<ActionResult<Project>> Create(Project project)
        {
            if (string.IsNullOrWhiteSpace(project.Name))
                return BadRequest(new { error = "Project name is required." });

            _db.Projects.Add(project);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = project.Id }, project);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, Project update)
        {
            if (id != update.Id && update.Id != 0)
                return BadRequest(new { error = "Id in URL and body must match." });

            var existing = await _db.Projects.FindAsync(id);
            if (existing == null)
                return NotFound(new { error = $"Project with id {id} not found." });

            existing.Name = update.Name;
            existing.Description = update.Description;
            existing.Completed = update.Completed;

            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
