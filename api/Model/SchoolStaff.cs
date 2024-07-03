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
        public string staffName { get; set; }
        public string staffEmail { get; set; }
        public string staffPosition { get; set; }
        public int departmentId { get; set; }
        public Department department { get; set; }

    }
}