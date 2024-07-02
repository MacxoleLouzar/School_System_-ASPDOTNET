using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    [Table("Department")]
    public class Department
    {
        public int departmentId { get; set; }
        public string departmentName { get; set; } = string.Empty;
        public ICollection<SchoolStaff> staffs { get; set; }
    }
}