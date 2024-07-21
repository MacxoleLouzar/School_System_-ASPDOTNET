using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Model;

namespace api.Interfaces
{
    public interface ISchoolStaffRepository
    {
        Task<List<SchoolStaff>> GetAllAsync();
        Task<SchoolStaff?> GetByIdAsync(int id);
        //Task<SchoolStaff?> GetByUserIdAsync(int userId);
        Task<SchoolStaff> CreateAsync(SchoolStaff schoolStaff);
        Task<SchoolStaff?> UpdateAsync(int id, SchoolStaff schoolStaff);
        Task<SchoolStaff?> DeleteAsync(int id);
        
    }
}