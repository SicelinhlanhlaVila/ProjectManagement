using Microsoft.EntityFrameworkCore;
using ProjectManagement.API.Data;
using ProjectManagement.API.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ProjectManagement.API.Services
{
    public class ProjectService : IProjectsService
    {
        private readonly AppDbContext _db;

        public ProjectService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Project> AddProject(Project project)
        {
            _db.Projects.Add(project);
            await _db.SaveChangesAsync();
            return project;
        }

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

        public async Task<IEnumerable<Project>> GetAllProjects()
        {
            var projects = await _db.Projects.AsNoTracking().ToListAsync();
            return projects;
        }
    }
}
