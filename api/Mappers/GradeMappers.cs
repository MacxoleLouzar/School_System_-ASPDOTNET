using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.GradeDTO;
using api.DTO.StudentDTO;
using api.Model;

namespace api.Mappers
{
    public static class GradeMappers
    {
        public static GradeCreateDTO ToCreateGradeDto(this GradeCreateDTO  gradeCreateDTO)
        {
            return new GradeCreateDTO
            {
                GradeName = gradeCreateDTO.GradeName,
                Year = gradeCreateDTO.Year
            };
        }
        public static Grades ToReadGradeDto(this Grades grade)
        {
            return new Grades
            {
                GradeId = grade.GradeId,
                GradeName = grade.GradeName,
                Year = grade.Year,
                Students = GradeListDTO.Students?.Select(x => x.ToStudentListDTOs()).ToList(),
                streams = grade.streams
                
            };
        }
        public static GradeUpdateDTO ToEditGradeDto(this GradeUpdateDTO gradeUpdateDTO)
        {
            return new GradeUpdateDTO
            {
                GradeName = gradeUpdateDTO.GradeName,
                Year = gradeUpdateDTO.Year
            };
        }
    }
}