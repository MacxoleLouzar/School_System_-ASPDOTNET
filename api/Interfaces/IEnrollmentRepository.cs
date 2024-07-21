using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Model;

namespace api.Interfaces
{
    public interface IEnrollmentRepository
    {
        Task<List<Enrollment>> GetAllEnrollmentsAsync();
        Task<Enrollment> GetEnrollmentsByID(int id);
        Task<Enrollment> CreateEnrollmentAsync(Enrollment enrollment);
        Task<Enrollment> UpdateEnrollmentAsync(int id, Enrollment enrollment);
        Task<Enrollment> DeleteEnrollmentAsync(int id);
    }
}