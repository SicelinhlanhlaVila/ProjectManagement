using Microsoft.AspNetCore.Mvc;
using ProjectManagement.API.Models;
using ProjectManagement.API.Services;

namespace ProjectManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _skillService;
        public SkillsController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Skill>>> Get()
        {
            var skills = await _skillService.GetAll();
            return Ok(skills);
        }
    }
}
