using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.SchoolStaffDTO;
using api.Model;

namespace api.Mappers
{
    public static class SchoolStaffMappers
    {
        public static SchoolStaff ToSchoolStaffFromCreateDTO(this SchoolStaffFromCreateDTO schoolStaffFromCreateDTO, int departmentId){
            return new SchoolStaff{
               staffName = schoolStaffFromCreateDTO.staffName,
               staffEmail = schoolStaffFromCreateDTO.staffEmail,
               staffPosition = schoolStaffFromCreateDTO.staffPosition,
               departmentId = departmentId // to check if department exists
            };
        }

        public static SchoolStaffListDTO ToSchoolStaffDTO(this SchoolStaff schoolStaff){
            return new SchoolStaffListDTO{
                staffName = schoolStaff.staffName,
                staffEmail = schoolStaff.staffEmail,
                staffPosition = schoolStaff.staffPosition,
                departmentId = schoolStaff.departmentId
            };
        }

        public static SchoolStaff ToSchoolStaffFromUpdateDTO(this SchoolStaffFromUpdateDTO schoolStaffFromUpdateDTO, int departmentId){
            return new SchoolStaff{
                staffName = schoolStaffFromUpdateDTO.staffName,
                staffEmail = schoolStaffFromUpdateDTO.staffEmail,
                staffPosition = schoolStaffFromUpdateDTO.staffPosition,
                departmentId = departmentId
            };
        }
    }
}