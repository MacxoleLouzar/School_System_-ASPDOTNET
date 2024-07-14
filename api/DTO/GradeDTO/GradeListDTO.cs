using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Model;

namespace api.DTO.GradeDTO
{
    public class GradeListDTO
    {
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public DateTime Year { get; set; }
        public ICollection<Student> Students { get; set; }
        public Streams streams{ get; set; }
    }
}