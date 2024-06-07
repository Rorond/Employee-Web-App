using Dapper;
using Employee.Data.DataAccess;
using Employee.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model = Employee.Data.Models.Employee;

namespace Employee.Data.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly ISqlDataAccess _db;
        public EmployeeRepository(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<int> AddAsync(Model model)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.AddDynamicParams(new { model.Id, model.Position, model.Name, model.Nik, model.Place_Of_Birth, model.Birth, model.Gender, model.Religion,
                model.Blood_Group,model.Status, model.Address_Ktp,model.Address_Life,model.Email,model.Tlp,model.Relatives,model.Skill,model.Readdy_To_Be_Placed,model.Expected_Sallary});
              
                await _db.SaveData("sp_create_employee", parameters);

                return parameters.Get<int>("@id");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public async Task<bool> UpdateAsync(Model model)
        {
            try
            {
                await _db.SaveData("sp_update_employee", model);
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
                await _db.SaveData("sp_delete_employee", new { Id = id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Model?> FindAsync(int id)
        {
            IEnumerable<Model> result = await _db.GetData<Model, dynamic>("sp_find_employee", new { Id = id });
            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<Model>> GetAllAsync()
        {
            string query = "sp_all_employee";
            return await _db.GetData<Model, dynamic>(query, new { });
        }
    }
}
