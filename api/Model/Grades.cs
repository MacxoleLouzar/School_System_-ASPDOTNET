using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    [Table("Grade")]
    public class Grades
    {
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public DateTime Year { get; set; }
        public ICollection<Student> Students { get; set; }
        public Stream stream{ get; set; }
    }
}