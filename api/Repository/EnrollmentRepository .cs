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
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly ApplicationDbContext _context;
        public EnrollmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Enrollment> CreateEnrollmentAsync(Enrollment enrollment)
        {
            await _context.Enrollments.AddAsync(enrollment);
            await _context.SaveChangesAsync();
            return enrollment;
        }

        public async Task<Enrollment> DeleteEnrollmentAsync(int id)
        {
            var enrollment = await _context.Enrollments.FirstOrDefaultAsync(x => x.EnrollmentID == id);
            if (enrollment == null)
            {
                return null;
            }
            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();
            return enrollment;
        }

        public async Task<List<Enrollment>> GetAllEnrollmentsAsync()
        {
            var enrol = await _context.Enrollments.Include(x => x.Students).ToListAsync();
            return enrol;
        }

        public async Task<List<Enrollment>> GetEnrollmentsByID(int id)
        {
           var enrolments = await _context.Enrollments.Where(x => x.EnrollmentID == id).ToListAsync();
           if(enrolments.Count == 0){
            return null;
           }
           return enrolments;
        }

        public async Task<Enrollment> UpdateEnrollmentAsync(int id, Enrollment enrollment)
        {
            var enrolment = await _context.Enrollments.SingleOrDefaultAsync(x => x.EnrollmentID==id);
            if(enrolment == null){
                return null;
            }
            
            enrolment.EnrollmentDate = enrollment.EnrollmentDate;
            await _context.SaveChangesAsync();
            return enrollment;
        }

      
    }
}