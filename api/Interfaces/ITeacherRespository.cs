using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Model;

namespace api.Interfaces
{
    public interface ITeacherRespository
    {
        Task<List<Teacher>> GetTeachersAsync();
        Task<Teacher?> GetTeacherByIdAsync(int id);
        Task<Teacher?> CreateTeacherAsync(Teacher teacher);
        Task<Teacher?> UpdateTeacherAsync(int id, Teacher teacher);
        Task<Teacher?> DeleteTeacherAsync(int id);

    }
}