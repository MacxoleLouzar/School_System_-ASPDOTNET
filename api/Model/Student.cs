using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    [Table("Student")]
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string StudentSurname { get; set; }= string.Empty;
        public string DOB { get; set; } = string.Empty;
        public string StudentGender { get; set; }= string.Empty;
        public string StudentPhone { get; set; }= string.Empty;
        public string StudentEmail { get; set; }= string.Empty;
        public string StudentAddress { get; set; }= string.Empty;
        public DateTime EnrollmentDate { get; set; }

        internal object ToStudentDto()
        {
            throw new NotImplementedException();
        }
    }
}