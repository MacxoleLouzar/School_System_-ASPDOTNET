using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTO.StreamDTO
{
    public class CreateStreamDTO
    {
        public string StreamName { get; set; } = String.Empty;
        public string? Description { get; set; }
        
    }
}