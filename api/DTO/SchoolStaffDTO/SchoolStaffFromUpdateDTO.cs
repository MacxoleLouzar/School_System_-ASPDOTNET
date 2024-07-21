using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTO.SchoolStaffDTO
{
    public class SchoolStaffFromUpdateDTO
    {
        public string staffName { get; set; }= string.Empty;
        public string staffEmail { get; set; }= string.Empty;
        public string staffPosition { get; set; } = string.Empty;
        public int departmentId { get; set; }
    }
}