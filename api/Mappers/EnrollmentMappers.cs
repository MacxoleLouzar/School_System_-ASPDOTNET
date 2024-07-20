using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.EnrollmentDTO;
using api.Model;

namespace api.Mappers
{
    public static class EnrollmentMappers
    {
      
        public static EnrollmentListDTO ToEnrollmentListDTO(this Enrollment enrollment)
        {
            return new EnrollmentListDTO
            {
                EnrollmentDate = enrollment.EnrollmentDate,
                Students = enrollment.Students.Select(x => x.ToStudentListDTO()).ToList(),
                Subjects = enrollment.Subjects.Select(x => x.ToSubjectListDTO()).ToList()
            };
        }

        public static Enrollment ToEnrollmentFromCreateDTO(this EnrollmentCreateDTO createEnrollmentRequestDTO)
        {
            return new Enrollment
            {
                EnrollmentDate = createEnrollmentRequestDTO.EnrollmentDate
            };
        }

        public static Enrollment ToEnrollmentFromUpdateDTO(this EnrollmentUpdateDTO updateEnrollmentRequestDTO)
        {
            return new Enrollment
            {
                EnrollmentDate = updateEnrollmentRequestDTO.EnrollmentDate
            };
        }
    }
}