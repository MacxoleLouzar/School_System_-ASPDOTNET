using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Model;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Grades> Grades { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Streams> Streams { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<AttendenceRegister> Attendances { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<SchoolStaff> SchoolStaff { get; set; }
    }
}