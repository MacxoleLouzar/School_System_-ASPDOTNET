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
    public class GradeRepository : IGradeRepository
    {
        private readonly ApplicationDbContext _context;
        public GradeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Grades> CreateGradeAsync(Grades grade)
        {
            await _context.Grades.AddAsync(grade);
            await _context.SaveChangesAsync();
            return grade;
        }

        public async Task<Grades> DeleteGradeAsync(int gradeId)
        {
            var grade = await _context.Grades.FindAsync(gradeId);
            if (grade == null){
                return null;
            }
             _context.Grades.Remove(grade);
            await _context.SaveChangesAsync();
            return grade;
        }

        public async Task<Grades> GetGradeByIdAsync(int gradeId)
        {
            var grade = await _context.Grades.FirstOrDefaultAsync(x => x.GradeId == gradeId);
            if (grade == null){
                return null;
            }
            return grade;
        }

        public async Task<List<Grades>> GetGradesAsync()
        {
            var grade = await _context.Grades.Include(x => x.Students).ToListAsync();
            return grade;
        }

        public async Task<Grades> UpdateGradeAsync(int id, Grades grade)
        {
            var gradeToUpdate = await _context.Grades.FindAsync(id);
            if (gradeToUpdate == null){
                return null;
            }
            gradeToUpdate.GradeName = grade.GradeName;
            gradeToUpdate.Year = grade.Year;
            gradeToUpdate.streams = grade.streams;
            gradeToUpdate.Students = grade.Students;
            await _context.SaveChangesAsync();
            return grade;
        }
    }
}