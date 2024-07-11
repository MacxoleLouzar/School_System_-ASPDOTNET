using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.TeacherDTO;
using api.Model;

namespace api.Mappers
{
    public static class TeacherMappers
    {
        public static TeachersListDTO ToTeacherListDTO(this Teacher teacherModel)
        {
            return new TeachersListDTO
            {
               TeacherFirstName = teacherModel.TeacherFirstName,
               TeacherLastName = teacherModel.TeacherLastName,
               TeacherEmail = teacherModel.TeacherEmail,
               TeacherAddress = teacherModel.TeacherAddress,
               TeacherPhone = teacherModel.TeacherPhone,
               DOB = teacherModel.DOB,
               TeacherGender = teacherModel.TeacherGender,
               TeacherHiredDate = teacherModel.TeacherHiredDate,
               TeacherRole = teacherModel.TeacherRole
            };
        }
        public static Teacher ToTeacherCreateDTO(this TeacherCreateDTO addTeacherDTO)
        {
            return new Teacher
            {    
               TeacherFirstName = addTeacherDTO.TeacherFirstName,
               TeacherLastName = addTeacherDTO.TeacherLastName,
               TeacherEmail = addTeacherDTO.TeacherEmail,
               TeacherAddress = addTeacherDTO.TeacherAddress,
               TeacherPhone = addTeacherDTO.TeacherPhone,
               DOB = addTeacherDTO.DOB,
               TeacherGender = addTeacherDTO.TeacherGender,
               TeacherHiredDate = addTeacherDTO.TeacherHiredDate,
               TeacherRole = addTeacherDTO.TeacherRole
            };
        }

        public static Teacher ToTeacherUpdateDTO(this TeacherUpdateDTO updateTeacherDTO)
        {
            return new Teacher
            {
               TeacherFirstName = updateTeacherDTO.TeacherFirstName,
               TeacherLastName = updateTeacherDTO.TeacherLastName,
               TeacherEmail = updateTeacherDTO.TeacherEmail,
               TeacherAddress = updateTeacherDTO.TeacherAddress,
               TeacherPhone = updateTeacherDTO.TeacherPhone,
               DOB = updateTeacherDTO.DOB,
               TeacherGender = updateTeacherDTO.TeacherGender,
               TeacherHiredDate = updateTeacherDTO.TeacherHiredDate,
               TeacherRole = updateTeacherDTO.TeacherRole
            };
        }
    }
}