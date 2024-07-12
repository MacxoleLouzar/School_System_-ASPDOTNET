using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Model;

namespace api.Interfaces
{
    public interface ISubjectRespository
    {
        Task<List<Subject>> GetAllSubjectsAsync();
        Task<Subject> GetSubjectByIdAsync(int id);
        Task<Subject> CreateSubjectAsync(Subject subject);
        Task<Subject> UpdateSubjectAsync(int id, Subject subject);
        Task<bool> DeleteSubjectAsync(int id);
    }
}