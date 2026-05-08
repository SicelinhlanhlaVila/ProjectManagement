using Microsoft.EntityFrameworkCore;
using ProjectManagement.API.Data;
using ProjectManagement.API.DTOs;
using ProjectManagement.API.Models;
using System.Globalization;
using System.Linq.Expressions;

namespace ProjectManagement.API.Services
{
    /// <summary>
    /// Service implementation to manage dashboard
    /// </summary>
    public class DashboardService : IDashboardService
    {

        private readonly AppDbContext _db;

        /// <summary>
        /// Initializes the constructor
        /// </summary>
        /// <param name="db"></param>
        public DashboardService(AppDbContext db) => _db = db;
    
        /// <summary>
        /// Gets the dashboard summary
        /// </summary>
        /// <returns></returns>
        public async Task<DashboardSummaryDto> GetDashboardSummary()
        {
            var totalProjects = await _db.Projects.CountAsync();
            var (finishedProjects, featuredProjects) = await GetProjectsCount();

            var dashboardSummary = new DashboardSummaryDto
            {
                TotalProjects = totalProjects,
                FinishedProjects = finishedProjects,
                FeaturedProjects = featuredProjects
            };

            return dashboardSummary;
        }

        /// <summary>
        /// Gets a list of all techs used and how many times
        /// </summary>
        /// <returns></returns>
        public async Task<List<TechUsageDto>> GetTechUsage()
        {
            var projects = await _db.Projects.ToListAsync();

            var techUsage = projects
                            .SelectMany(project => project.Tech)
                            .Where(tech => !string.IsNullOrEmpty(tech))
                            .Select(tech => tech.Trim().ToLower())
                            .GroupBy(tech => tech)
                            .Select(g => new TechUsageDto
                            {
                                Tech = g.Key,
                                Count = g.Count()
                            })
                            .OrderByDescending(tech => tech.Count)
                            .ToList();

            return techUsage;
        }

        /// <summary>
        /// Gets recently completed projects
        /// </summary>
        /// <returns></returns>
        public async Task<List<RecentlyCompletedProjectsDto>> GetRecentlyCompletedProjects()
        {
            var projects = await _db.Projects.ToListAsync();

            var recentProjects = projects
                                 .Where(p => p.IsFinished)
                                 .OrderByDescending(p => p.EndDate)
                                 .Take(3)
                                 .Select(p => new RecentlyCompletedProjectsDto
                                 {
                                     ProjectId = p.Id,
                                     ProjectName = p.Name,
                                     Description = p.Description,
                                     CompletedDate = p.EndDate.ToString("dd MMMM yyyy", CultureInfo.InvariantCulture)
                                 })
                                 .ToList();

            return recentProjects;
        }

        private async Task<Tuple<int,int>> GetProjectsCount()
        {
            var finishedProjects = await CountByExpression(x => x.IsFinished);
            var featuredProjects = await CountByExpression(x => x.Featured);

            return Tuple.Create(finishedProjects, featuredProjects);
        }
        private async Task<int> CountByExpression(Expression<Func<Project, bool>> predicate)
        {
            var count = await _db.Projects.CountAsync(predicate);
            return count;
        }
    }
}
