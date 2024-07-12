using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Model;

namespace api.DTO.StreamDTO
{
    public class StreamListDTO
    {
        public int StreamId { get; set; }
        public string StreamName { get; set; } = String.Empty;
        public string? Description { get; set; }
        public ICollection<Subject?> Subjects { get; set; }
    }
}