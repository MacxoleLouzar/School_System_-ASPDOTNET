using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTO.SubjectDTO
{
    public class SubjectUpdateDTO
    {
        
        public int SubjectId { get; set; }
        public string SubjectName { get; set; } = String.Empty;
        public string SubjectCode { get; set; } = String.Empty;
        public string schedule { get; set; } = String.Empty;
    }
}