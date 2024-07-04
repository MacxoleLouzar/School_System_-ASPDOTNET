using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.StudentDTO;
using api.Model;

namespace api.Mappers
{
    public static class StudentMappers
    {
        public static StudentListDTOs ToStudentListDTOs(this Student studentModel)
        {
            return new StudentListDTOs
            {
                StudentID = studentModel.StudentID,
                StudentName = studentModel.StudentName,
                StudentSurname = studentModel.StudentSurname,
                StudentEmail = studentModel.StudentEmail,
                StudentPhone = studentModel.StudentPhone,
                StudentAddress = studentModel.StudentAddress,
                StudentGender = studentModel.StudentGender,
                DOB = studentModel.DOB,
               EnrollmentDate = studentModel.EnrollmentDate
            };
        }

        public static Student ToCreateStudentDTO(this StudentCreateDTO studentCreateDTOs)
        {
            return new Student
            {
                StudentName = studentCreateDTOs.StudentName,
                StudentSurname = studentCreateDTOs.StudentSurname,
                StudentEmail = studentCreateDTOs.StudentEmail,
                StudentPhone = studentCreateDTOs.StudentPhone,
                StudentAddress = studentCreateDTOs.StudentAddress,
                StudentGender = studentCreateDTOs.StudentGender,
                DOB = studentCreateDTOs.DOB,
                EnrollmentDate = studentCreateDTOs.EnrollmentDate
            };
        }

          public static Student ToUpdateStudentDTO(this StudentUpdateDTO studentUpdateDTO)
        {
            return new Student
            {
                StudentName = studentUpdateDTO.StudentName,
                StudentSurname = studentUpdateDTO.StudentSurname,
                StudentEmail = studentUpdateDTO.StudentEmail,
                StudentPhone = studentUpdateDTO.StudentPhone,
                StudentAddress = studentUpdateDTO.StudentAddress,
                StudentGender = studentUpdateDTO.StudentGender,
                DOB = studentUpdateDTO.DOB,
                EnrollmentDate = studentUpdateDTO.EnrollmentDate
            };
        }
    }
}