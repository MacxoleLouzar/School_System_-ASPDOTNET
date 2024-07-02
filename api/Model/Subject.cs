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
        public string SubjectName { get; set; }
        public string SubjectCode { get; set; }
        public string schedule { get; set; }
        public int TeacherId { get; set; }
        public int StreamId { get; set; }
        public Stream Stream { get; set; }
        public Teacher Teacher { get; set; }
    }
}