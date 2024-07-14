using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTO.GradeDTO
{
    public  class GradeCreateDTO
    {
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public DateTime Year { get; set; }
        
    }
}