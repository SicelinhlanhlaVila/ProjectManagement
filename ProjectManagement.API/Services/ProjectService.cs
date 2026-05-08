using Microsoft.EntityFrameworkCore;
using ProjectManagement.API.Data;
using ProjectManagement.API.DTOs;
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
            project.StartDate = DateTime.Now;
            project.EndDate = DateTime.Now.AddMonths(1);
            project.IsFinished = false;
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
                existingProject.IsFinished = project.IsFinished;
                existingProject.Tech = project.Tech;
                existingProject.Details = project.Details;

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

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteProject(int id)
        {
            var toBeDeleted = await _db.Projects.FindAsync(id);
            if (toBeDeleted == null)
                throw new Exception("cannot delete a project that does not exist");
            else
            {
                _db.Remove(toBeDeleted);
                await _db.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Completes a project
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task CompleteProject(int id)
        {
            var project = await _db.Projects.FindAsync(id);
            if (project == null)
                throw new Exception("project does not exist");
            else
            {
                project.IsFinished = true;
                project.EndDate = DateTime.Now;
                await _db.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Gets full project details
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ProjectDetailsDto</returns>
        public async Task<ProjectDetailsDto> GetFullProjectDetails(int id)
        {
            var project = await _db.Projects.FindAsync(id);

            if (project == null)
                throw new Exception("project does not exist");

            var details = CreateDetailsParagraph(project.StartDate,project.EndDate,project.Tech,project.IsFinished);

            var projectDetails = new ProjectDetailsDto
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                Featured = project.Featured,
                Tech = project.Tech,
                Details = details
            };

            return projectDetails;
        }

        /// <summary>
        /// private method to build string
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="tech"></param>
        /// <param name="isFinished"></param>
        /// <returns></returns>
        private static string CreateDetailsParagraph(DateTime startDate, DateTime endDate, string[] tech,bool isFinished)
        {
            var calcDateDif = (endDate - startDate).Days;
            string completedText = string.Empty;
            string techText = string.Empty;

            if (tech != null && tech.Length == 1)
                techText = $"with only just {tech[0]}";
            else
                techText = $"with more than one technology.";

            if (isFinished)
                completedText = $"completed in {calcDateDif} days ";
            else
                completedText = $"and is set to complete in {calcDateDif} days ";

            var details = $"Started working on it on {startDate.ToShortDateString()} " +
                          completedText +
                          techText;

            return details;
        }
    }
}
