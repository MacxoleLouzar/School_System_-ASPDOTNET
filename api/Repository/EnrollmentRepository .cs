using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Model;

namespace api.Repository
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly ApplicationDbContext _context;
        public EnrollmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<Enrollment> CreateEnrollmentAsync(Enrollment enrollment)
        {
            throw new NotImplementedException();
        }

        public Task<Enrollment> DeleteEnrollmentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Enrollment>> GetAllEnrollmentsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Enrollment>> GetEnrollmentsByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Enrollment> UpdateEnrollmentAsync(Enrollment enrollment)
        {
            throw new NotImplementedException();
        }
    }
}