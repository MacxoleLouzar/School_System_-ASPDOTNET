using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    [Table("Student")]
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }
        public string DOB { get; set; }
        public string StudentGender { get; set; }
        public string StudentPhone { get; set; }
        public string StudentEmail { get; set; }
        public string StudentAddress { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}