using Employee.Data.DataAccess;
using Employee.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ISqlDataAccess _db;
        public UserRepository(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<bool> AddAsync(User model)
        {
            try
            {
                await _db.SaveData("sp_create_user", new { model.Email, model.Password });
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(User model)
        {
            try
            {
                await _db.SaveData("sp_update_user", model);
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await _db.SaveData("sp_delete_user", new { Id = id });
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<User?> LoginAsync(string email, string password)
        {
            IEnumerable<User> result = await _db.GetData<User, dynamic>("sp_login_user", new { Email = email, Password = password });
            return result.FirstOrDefault();
        }

        public async Task<User?> FindAsync(int id)
        {
            IEnumerable<User> result = await _db.GetData<User, dynamic>("sp_find_user", new { Id = id });
            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            string query = "sp_all_user";
            return await _db.GetData<User, dynamic>(query, new { });
        }

    }
}
