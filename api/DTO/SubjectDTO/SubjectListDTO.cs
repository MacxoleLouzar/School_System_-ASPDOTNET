using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Model;

namespace api.DTO.SubjectDTO
{
    public class SubjectListDTO
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