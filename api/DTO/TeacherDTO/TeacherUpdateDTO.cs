using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTO.TeacherDTO
{
    public class TeacherUpdateDTO
    {
        public int TeacherID { get; set; }
        public string TeacherFirstName { get; set; }
        public string TeacherLastName { get; set; }
        public string DOB { get; set; }
        public string TeacherGender { get; set; }
        public string TeacherAddress { get; set; }
        public string TeacherPhone { get; set; }
        public string TeacherEmail { get; set; }
        public DateTime TeacherHiredDate { get; set; }
        public string TeacherRole { get; set; }
    }
}