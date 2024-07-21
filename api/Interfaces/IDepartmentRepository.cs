using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Model;

namespace api.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetAllAsync();
        Task<Department?> GetByIdAsync(int id);
        Task<Department> CreateAsync(Department department);    
        Task<Department?> UpdateAsync(int id, Department department);
        Task<Department?> DeleteAsync(int id);
    }
}