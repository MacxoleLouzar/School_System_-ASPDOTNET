using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Model;
using api.Data;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class SchoolStaffRepository : ISchoolStaffRepository
    {
        private readonly ApplicationDbContext _context;
        public SchoolStaffRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<SchoolStaff> CreateAsync(SchoolStaff schoolStaff)
        {
            var result = await _context.SchoolStaff.AddAsync(schoolStaff);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<SchoolStaff?> DeleteAsync(int id)
        {
            var schoolStaff = await _context.SchoolStaff.FindAsync(id);
            if(schoolStaff == null)
            {
                return null;
            }
            var result = _context.SchoolStaff.Remove(schoolStaff);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<List<SchoolStaff>> GetAllAsync()
        {
            var result = await _context.SchoolStaff.ToListAsync();
            return result;
        }

        public async Task<SchoolStaff?> GetByIdAsync(int id)
        {
            var schoolStaff = await _context.SchoolStaff.FindAsync(id);
            if(schoolStaff == null)
            {
                return null;
            }
            return schoolStaff;
        }

        public async Task<SchoolStaff?> UpdateAsync(int id, SchoolStaff schoolStaff)
        {
            var existingSchoolStaff = await _context.SchoolStaff.FindAsync(id);
            if(existingSchoolStaff == null)
            {
                return null;
            }
            existingSchoolStaff.staffName = schoolStaff.staffName;
            existingSchoolStaff.staffEmail = schoolStaff.staffEmail;
            existingSchoolStaff.staffPosition = schoolStaff.staffPosition;
            await _context.SaveChangesAsync();
            return existingSchoolStaff;

        }
    }

}