using ProjectManagement.API.Models;

namespace ProjectManagement.API.Services
{
    /// <summary>
    /// provides operations to handle project related logic
    /// </summary>
    public interface IProjectsService
    {
        /// <summary>
        /// gets all projects
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Project>> GetAllProjects();

        /// <summary>
        /// adds a new project
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        Task<Project> AddProject(Project project);

        /// <summary>
        /// updates an existing project
        /// </summary>
        /// <param name="id"></param>
        /// <param name="project"></param>
        /// <returns></returns>
        Task EditProject(int id, Project project);
    }
}
