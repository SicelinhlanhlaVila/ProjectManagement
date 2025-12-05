using Microsoft.AspNetCore.Mvc;
using ProjectManagement.API.Models;
using ProjectManagement.API.Services;

namespace ProjectManagement.API.Controllers
{
    /// <summary>
    /// Provides logic to handle Projects
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectsService _projectsService;

        /// <summary>
        /// Initializes the constructor
        /// </summary>
        /// <param name="projectsService"></param>
        public ProjectsController(IProjectsService projectsService)
        {
            _projectsService = projectsService;
        }

        /// <summary>
        /// Gets all projects
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> Get()
        {
            var projects = await _projectsService.GetAllProjects();
            return Ok(projects);
        }

        /// <summary>
        /// Adds a new project
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Project>> Create(Project project)
        {
            if (string.IsNullOrWhiteSpace(project.Name))
                return BadRequest(new { error = "Project name is required." });
            var newProject = await _projectsService.AddProject(project);

            return CreatedAtAction(nameof(Get), new { id = newProject.Id }, newProject);
        }

        /// <summary>
        /// Updates an existing project
        /// </summary>
        /// <param name="id"></param>
        /// <param name="update"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, Project update)
        {
            if (id != update.Id && update.Id != 0)
                return BadRequest(new { error = "Id in URL and body must match." });

            await _projectsService.EditProject(id, update);
           
            return NoContent();
        }
    }
}
