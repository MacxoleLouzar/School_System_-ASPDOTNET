using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    [Table("Attendence")]
    public class AttendenceRegister
    {
        public int AttendenceRegisterId { get; set; }
        public int StudentId { get; set; }
        public DateTime Date { get; set; }  = DateTime.UtcNow;
        public Student? Student { get; set; }
    }
}