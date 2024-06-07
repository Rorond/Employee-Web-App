using Employee.Data.Models;

namespace Employee.Data.Repository
{
    public interface IUserRepository
    {
        Task<bool> AddAsync(User model);
        Task<bool> UpdateAsync(User model);
        Task<bool> DeleteAsync(int id);
        Task<User?> LoginAsync(string email, string password);
        Task<User?> FindAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();
    }
}