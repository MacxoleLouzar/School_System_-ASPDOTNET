using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Model;

namespace api.DTO.SchoolStaffDTO
{
    public class SchoolStaffListDTO
    {
        public int staffId { get; set; }
        public string staffName { get; set; }= string.Empty;
        public string staffEmail { get; set; }= string.Empty;
        public string staffPosition { get; set; } = string.Empty;
        public int? departmentId { get; set; }
    }
}