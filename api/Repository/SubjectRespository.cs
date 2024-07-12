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
    public class SubjectRespository : ISubjectRespository
    {
        private readonly ApplicationDbContext _context;

        public SubjectRespository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Subject> CreateSubjectAsync(Subject subject)
        {
            await _context.Subjects.AddAsync(subject);
            await _context.SaveChangesAsync();
            return subject;
        }

        public async Task<bool> DeleteSubjectAsync(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null)
            {
                return false;
            }

            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();
            return true;
        }
        

        public async Task<List<Subject>> GetAllSubjectsAsync()
        {
           var subjects = await _context.Subjects.ToListAsync();
           return subjects;
        }

        public async Task<Subject> GetSubjectByIdAsync(int id)
        {
            var subject = await _context.Subjects.Include(x => x.Teacher).FirstOrDefaultAsync(x => x.SubjectId == id);
            if (subject == null)
            {
                return null;
            }
            return subject;
        }

        public async Task<Subject> UpdateSubjectAsync(int id, Subject subject)
        {
            var existingSubject = await _context.Subjects.FindAsync(id);
            if (existingSubject == null)
            {
                return null;
            }
            existingSubject.SubjectName = subject.SubjectName;
            existingSubject.SubjectCode = subject.SubjectCode;
            existingSubject.schedule = subject.schedule;

            await _context.SaveChangesAsync();
            return existingSubject;
        }
    }
}