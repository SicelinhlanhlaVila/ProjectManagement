using Microsoft.EntityFrameworkCore;
using ProjectManagement.API.Data;
using ProjectManagement.API.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ProjectManagement.API.Services
{
    /// <summary>
    /// Provides operations handle all project related logic
    /// </summary>
    public class ProjectService : IProjectsService
    {
        private readonly AppDbContext _db;

        /// <summary>
        /// Initializes the constructor
        /// </summary>
        /// <param name="db"></param>
        public ProjectService(AppDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Adds a new project
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        public async Task<Project> AddProject(Project project)
        {
            _db.Projects.Add(project);
            await _db.SaveChangesAsync();
            return project;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="project"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task EditProject(int id, Project project)
        {
            var existingProject = await _db.Projects.FindAsync(id);
            if (existingProject == null)
                throw new Exception("project does not exist");
            else
            {
                existingProject.Name = project.Name;
                existingProject.Description = project.Description;
                existingProject.Completed = project.Completed;

                await _db.SaveChangesAsync();
            }
        }

        /// <summary>
        /// gets all projects
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Project>> GetAllProjects()
        {
            var projects = await _db.Projects.AsNoTracking().ToListAsync();
            return projects;
        }
    }
}
