using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    public class SchoolStaff
    {
        public int staffId { get; set; }
        public string staffName { get; set; }
        public string staffEmail { get; set; }
        public string staffPosition { get; set; }
        public int departmentId { get; set; }
        
    }
}