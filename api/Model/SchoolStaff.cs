using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    [Table("SchoolStaff")]
    public class SchoolStaff
    {
        [Key]
        public int staffId { get; set; }
        public string staffName { get; set; }= string.Empty;
        public string staffEmail { get; set; }= string.Empty;
        public string staffPosition { get; set; } = string.Empty;
        public int departmentId { get; set; }
        public Department department { get; set; }

    }
}