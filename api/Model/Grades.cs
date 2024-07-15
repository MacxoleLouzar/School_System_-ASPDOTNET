using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    [Table("Grades")]
    public class Grades
    {
        [Key]
        public int GradeId { get; set; }
        public string GradeName { get; set; } = String.Empty;
        public DateTime Year { get; set; }
        public List<Student?> Students { get; set; } = new List<Student?>();
        public int StreamId { get; set; } = 0;
        public Streams? streams{ get; set; }
    }
}