using Employee.Data.DataAccess;
using Employee.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model = Employee.Data.Models.CareerHistory;

namespace Employee.Data.Repository
{
    public class CareerRepository : ICareerRepository
    {

        private readonly ISqlDataAccess _db;
        public CareerRepository(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<bool> AddAsync(Model model)
        {
            try
            {
                await _db.SaveData("sp_create_career_histories", model);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Model model)
        {
            try
            {
                await _db.SaveData("sp_update_career_histories", model);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await _db.SaveData("sp_delete_career_histories", new { Id = id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Model?> FindAsync(int id)
        {
            IEnumerable<Model> result = await _db.GetData<Model, dynamic>("sp_find_career_histories", new { Id = id });
            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<Model>> GetAllAsync()
        {
            string query = "sp_all_career_histories";
            return await _db.GetData<Model, dynamic>(query, new { });
        }
    }
}
