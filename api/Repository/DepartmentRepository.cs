using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Model;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Department> CreateAsync(Department department)
        {
            var result = await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Department?> DeleteAsync(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if(department == null){
                return null;
            }
            var result = _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
        //Added for 1 to many relationship
        public Task<bool> DepartmentExists(int id)
        {
           return _context.Departments.AnyAsync(x => x.departmentId == id);
        }

        public async Task<List<Department>> GetAllAsync()
        {
            var result = await _context.Departments.Include(x => x.SchoolStaffs).ToListAsync();
            return result;
        }

        public async Task<Department?> GetByIdAsync(int id)
        {
            var result = await _context.Departments.Include(x => x.SchoolStaffs).FirstOrDefaultAsync(x => x.departmentId == id);
            return result;
        }

        public async Task<Department?> UpdateAsync(int id, Department department)
        {
            var departmentToUpdate = await _context.Departments.FindAsync(id);
            if(departmentToUpdate == null){
                return null;
            }
            departmentToUpdate.departmentName = department.departmentName;
            await _context.SaveChangesAsync();
            return departmentToUpdate;
        }
    }
}