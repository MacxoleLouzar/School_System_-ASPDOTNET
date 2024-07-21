using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.DepartmentDTO;
using api.Model;

namespace api.Mappers
{
    public static class DepartmentMappers
    {
        public static Department ToDpartmentFromCreateDTO(this DepartCreateDTO createDpartmentRequestDTO)
        {
            return new Department
            {
                departmentName = createDpartmentRequestDTO.departmentName,
            };
        }
        public static DepartListDTO ToDepartmentDTO(this Department departmentModel)
        {
            return new DepartListDTO
            {
                departmentName = departmentModel.departmentName,
                SchoolStaffs = departmentModel.SchoolStaffs.Select(s => s.ToSchoolStaffDTO()).ToList()
            };
        }

        public static DepartUpdateDTO ToDepartUpdateDTO(this Department departmentModel)
        {
            return new DepartUpdateDTO
            {
                departmentName = departmentModel.departmentName
            };
        }
    }
}