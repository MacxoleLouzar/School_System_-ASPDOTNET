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
        public string TeacherFirstName { get; set; }
        public string TeacherLastName { get; set; }
        public string DOB { get; set; }
        public string TeacherGender { get; set; }
        public string TeacherAddress { get; set; }
        public string TeacherPhone { get; set; }
        public string TeacherEmail { get; set; }
        public DateTime TeacherHiredDate { get; set; }
        public string TeacherRole { get; set; }
        public ICollection<Subject> Subjects { get; set; }
    }
}