using ProjectManagement.API.Models;

namespace ProjectManagement.API.Services
{
    public interface IProjectsService
    {
        Task<IEnumerable<Project>> GetAllProjects();
        Task<Project> AddProject(Project project);
        Task EditProject(int id, Project project);
    }
}
