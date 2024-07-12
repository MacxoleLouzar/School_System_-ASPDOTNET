using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.SubjectDTO;
using api.Model;

namespace api.Mappers
{
    public static class SubjectMappers
    {
        public static Subject ToSubjectListDTO(this Subject subjectListDTO)
        {
            return new Subject
            {
                SubjectName = subjectListDTO.SubjectName,
                SubjectCode = subjectListDTO.SubjectCode,
                schedule = subjectListDTO.schedule,
                Teacher = subjectListDTO.Teacher,
                Streams = subjectListDTO.Streams
            };
        }
        public static Subject ToSubjectCreateDTO(this SubjectCreateDTO subjectCreateDTO)
        {
            return new Subject
            {
                SubjectName = subjectCreateDTO.SubjectName,
                SubjectCode = subjectCreateDTO.SubjectCode,
                schedule = subjectCreateDTO.schedule
            };
        }
        public static Subject ToSubjectUpdateDTO(this SubjectUpdateDTO subjectUpdateDTO)
        {
            return new Subject
            {
                SubjectName = subjectUpdateDTO.SubjectName,
                SubjectCode = subjectUpdateDTO.SubjectCode,
                schedule = subjectUpdateDTO.schedule
            };
        }
    }
}