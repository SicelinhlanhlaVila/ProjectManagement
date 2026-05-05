using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.API.DTOs;
using ProjectManagement.API.Services;

namespace ProjectManagement.API.Controllers
{
    /// <summary>
    /// Controller to manage dashboard 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        /// <summary>
        /// Initializes constructor
        /// </summary>
        /// <param name="dashboardService"></param>
        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        /// <summary>
        /// Gets the dashboard summary
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<DashboardSummaryDto>> GetDashboardSummary()
        {
            var dashboardSummary = await _dashboardService.GetDashboardSummary();
            return Ok(dashboardSummary);
        }

        /// <summary>
        ///  Gets a list of all techs used and how many times
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetTechUsage")]
        public async Task<ActionResult<IEnumerable<TechUsageDto>>> GetTechUsage()
        {
            var techUsage = await _dashboardService.GetTechUsage();
            return Ok(techUsage);
        }
    }
}
