using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    [Table("Subject")]
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; } = String.Empty;
        public string SubjectCode { get; set; } = String.Empty;
        public string schedule { get; set; } = String.Empty;
        public int TeacherId { get; set; }
        public int StreamId { get; set; }
        public Streams? Streams { get; set; }
        public Teacher? Teacher { get; set; }
    }
}