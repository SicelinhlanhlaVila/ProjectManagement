using ProjectManagement.API.DTOs;

namespace ProjectManagement.API.Services
{
    /// <summary>
    /// Service implementation to manage dashboard
    /// </summary>
    public interface IDashboardService
    {
        /// <summary>
        /// Gets the dashboard summary
        /// </summary>
        /// <returns></returns>
        Task<DashboardSummaryDto> GetDashboardSummary();

        /// <summary>
        /// Gets a list of all techs used and how many times
        /// </summary>
        /// <returns></returns>
        Task<List<TechUsageDto>> GetTechUsage();

        /// <summary>
        /// Gets the projects that were recently completed
        /// </summary>
        /// <returns></returns>
        Task<List<RecentlyCompletedProjectsDto>> GetRecentlyCompletedProjects();
    }
}
