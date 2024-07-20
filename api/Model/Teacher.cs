using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    [Table("Teacher")]
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string TeacherFirstName { get; set; } = string.Empty;
        public string TeacherLastName { get; set; } = string.Empty;
        public string DOB { get; set; } = string.Empty;
        public string TeacherGender { get; set; } = string.Empty;
        public string TeacherAddress { get; set; } = string.Empty;
        public string TeacherPhone { get; set; } = string.Empty;
        public string TeacherEmail { get; set; } = string.Empty;
        public DateTime TeacherHiredDate { get; set; }
        public string TeacherRole { get; set; } = string.Empty;
       
    }
}