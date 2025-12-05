using ProjectManagement.API.Models;

namespace ProjectManagement.API.Services
{
    /// <summary>
    /// Provides operations to handle all the skill logic
    /// </summary>
    public interface ISkillService
    {
        /// <summary>
        /// gets all available skills
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Skill>> GetAll();
    }
}
