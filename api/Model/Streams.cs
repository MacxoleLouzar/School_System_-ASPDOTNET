using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    [Table("Streams")]
    public class Streams
    {
        [Key]
        public int StreamId { get; set; }
        public string StreamName { get; set; }
        public string? Description { get; set; }
        public ICollection<Subject> Subjects { get; set; }
    
    }
}