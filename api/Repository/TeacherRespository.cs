using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class TeacherRespository : ITeacherRespository
    {
        private readonly ApplicationDbContext _context;
        public TeacherRespository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Teacher?> CreateTeacherAsync(Teacher teacher)
        {
            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
            return teacher;
        }

        public async Task<Teacher?> DeleteTeacherAsync(int id)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.TeacherId == id);
            if (teacher is not null)
            {
                _context.Teachers.Remove(teacher);
                await _context.SaveChangesAsync();
                return teacher;
            }
            return null;
        }

        public async Task<Teacher?> GetTeacherByIdAsync(int id)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.TeacherId == id);
            if (teacher is null)
            {
                return null;
            }
            return teacher;
        }

        public async Task<List<Teacher>> GetTeachersAsync()
        {
            var teachers = await _context.Teachers.Include(x => x.Subjects).ToListAsync();
            return teachers;
        }

        public async Task<Teacher?> UpdateTeacherAsync(int id, Teacher teacher)
        {
            var existingTeacher = await _context.Teachers.FirstOrDefaultAsync(x => x.TeacherId == id);
            if (existingTeacher is not null)
            {
                existingTeacher.TeacherFirstName = teacher.TeacherFirstName;
                existingTeacher.TeacherLastName = teacher.TeacherLastName;
                existingTeacher.TeacherEmail = teacher.TeacherEmail;
                existingTeacher.TeacherPhone = teacher.TeacherPhone;
                existingTeacher.TeacherAddress = teacher.TeacherAddress;
                existingTeacher.DOB = teacher.DOB;
                existingTeacher.Subjects = teacher.Subjects;

                _context.Teachers.Update(existingTeacher);
                await _context.SaveChangesAsync();
                return existingTeacher;
            }
            return null;
        }
    }
}