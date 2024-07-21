using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.SchoolStaffDTO;
using api.Model;

namespace api.DTO.DepartmentDTO
{
    public class DepartListDTO
    {
        public int departmentId { get; set; }
        public string departmentName { get; set; } = string.Empty;
        public List<SchoolStaffListDTO> SchoolStaffs { get; set; }
    }
}