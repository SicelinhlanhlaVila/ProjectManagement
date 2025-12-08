using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.API.Models;
using ProjectManagement.API.Services;

namespace ProjectManagement.API.Controllers
{
    /// <summary>
    ///  Provides logic to handle profiles
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
       private readonly IProfileService _profileService;

        /// <summary>
        /// Initializes the constructor
        /// </summary>
        /// <param name="profileService"></param>
        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        /// <summary>
        /// Gets the profile
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<Profile>> Get()
        {
           var profile = await _profileService.GetProfile();
            if (profile == null) return NotFound();
            return Ok(profile);
        }
    }
}

