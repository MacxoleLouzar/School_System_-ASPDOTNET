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
        public static Grades ToCreateGradeDto(this GradeCreateDTO gradeCreateDTO)
        {
            return new Grades
            {
                GradeName = gradeCreateDTO.GradeName,
                Year = gradeCreateDTO.Year
            };
        }
        public static GradeListDTO ToReadGradeDto(this Grades grade)
        {
            return new GradeListDTO
            {
                GradeId = grade.GradeId,
                GradeName = grade.GradeName,
                streams = grade.streams,
                Year = grade.Year,
                Students = grade.Students.Select(x => x.ToStudentListDTO()).ToList(),
            };
        }
        public static Grades ToEditGradeDto(this GradeUpdateDTO gradeUpdateDTO)
        {
            return new Grades
            {
                GradeName = gradeUpdateDTO.GradeName,
                Year = gradeUpdateDTO.Year
            };
        }
    }
}