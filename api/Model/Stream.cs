using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    [Table("Stream")]
    public class Stream
    {
        public int StreamId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Subject> Subjects { get; set; }
    
    }
}