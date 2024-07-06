using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.StudentDTO;
using api.Model;

namespace api.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudentsAsync();
        Task<Student> GetStudentByIdAsync(int studentId);
        Task<Student> AddStudentAsync(Student student);
        Task<Student> UpdateStudentAsync(int id, StudentUpdateDTO studentUpdateDTO);
        Task<Student> DeleteStudentAsync(int studentId);
    }

   
}