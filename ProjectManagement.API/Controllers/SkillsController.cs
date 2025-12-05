using Microsoft.AspNetCore.Mvc;
using ProjectManagement.API.Models;
using ProjectManagement.API.Services;

namespace ProjectManagement.API.Controllers
{
    /// <summary>
    /// Provides logic to handle skills operations
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _skillService;

        /// <summary>
        /// Initializes the constructor
        /// </summary>
        /// <param name="skillService"></param>
        public SkillsController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        /// <summary>
        /// Gets a list of all skills
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Skill>>> Get()
        {
            var skills = await _skillService.GetAll();
            return Ok(skills);
        }
    }
}
