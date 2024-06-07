using System.Reflection;
using Model = Employee.Data.Models.Training;
namespace Employee.Data.Repository
{
    public interface ITrainingRepository
    {
        Task<bool> AddAsync(Model model);
        Task<bool> UpdateAsync(Model model);
        Task<bool> DeleteAsync(int id);
        Task<Model?> FindAsync(int id);
        Task<IEnumerable<Model>> GetAllAsync();
    }
}