using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.GradeDTO;
using api.Model;

namespace api.Interfaces
{
    public interface IGradeRepository
    {
        Task<List<Grades>> GetGradesAsync();
        Task<Grades> GetGradeByIdAsync(int gradeId);
        Task<Grades> CreateGradeAsync(Grades grade);
        Task<Grades> UpdateGradeAsync(int id, Grades grade);
        Task<Grades> DeleteGradeAsync(int gradeId);
      
    }
}