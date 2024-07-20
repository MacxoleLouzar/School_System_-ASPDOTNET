using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.StudentDTO;
using api.Model;

namespace api.DTO.EnrollmentDTO
{
    public class EnrollmentListDTO
    {
        public int EnrollmentID { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public List<StudentListDTOs> Students { get; set; } = new List<StudentListDTOs>();
        public List<Subject> Subjects { get; set; } = new List<Subject>();
    }
}