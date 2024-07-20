using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Enrollment>()
            .HasKey(e => e.EnrollmentID);

            modelBuilder.Entity<Enrollment>()
                .HasMany(e => e.Students)
                .WithMany(e => e.Enrollments);
                
            modelBuilder.Entity<Enrollment>()
                .HasMany(e => e.Subjects)
                .WithMany(e => e.Enrollments);
        }
    }
}