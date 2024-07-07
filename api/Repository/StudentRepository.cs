using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTO.StudentDTO;
using api.Interfaces;
using api.Model;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int studentId)
        {
            var student = await _context.Students.FindAsync(studentId);
            if (student == null)
            {
                return null;
            }
            return student;
        }
        public async Task<Student> AddStudentAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            _context.SaveChanges();
            return student;
        }

        public async Task<Student> UpdateStudentAsync(int id, StudentUpdateDTO studentUpdateDTO)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return null;
            }
            student.StudentName = studentUpdateDTO.StudentName;
            student.StudentSurname = studentUpdateDTO.StudentSurname;
            student.StudentEmail = studentUpdateDTO.StudentEmail;
            student.StudentPhone = studentUpdateDTO.StudentPhone;
            student.StudentAddress = studentUpdateDTO.StudentAddress;
            student.StudentGender = studentUpdateDTO.StudentGender;
            student.DOB = studentUpdateDTO.DOB;
            student.EnrollmentDate = studentUpdateDTO.EnrollmentDate;

            await _context.SaveChangesAsync();
            return student;
        }
        public async Task<Student> DeleteStudentAsync(int studentId)
        {
           var student = await _context.Students.FindAsync(studentId);
            if (student == null)
            {
                return null;
            }
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return student;
        }
    }
}