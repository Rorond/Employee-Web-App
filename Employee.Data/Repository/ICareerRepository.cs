using System.Reflection;
using Model = Employee.Data.Models.CareerHistory;
namespace Employee.Data.Repository
{
    public interface ICareerRepository
    {
        Task<bool> AddAsync(Model model);
        Task<bool> UpdateAsync(Model model);
        Task<bool> DeleteAsync(int id);
        Task<Model?> FindAsync(int id);
        Task<IEnumerable<Model>> GetAllAsync();
    }
}