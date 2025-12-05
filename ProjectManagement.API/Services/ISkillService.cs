using ProjectManagement.API.Models;

namespace ProjectManagement.API.Services
{
    public interface ISkillService
    {
        Task<IEnumerable<Skill>> GetAll();
    }
}
