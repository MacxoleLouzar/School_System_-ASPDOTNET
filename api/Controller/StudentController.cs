using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _Context;
        public StudentController(ApplicationDbContext Context)
        {
            _Context = Context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _Context.Students.ToListAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById([FromRoute]int id)
        {
            var student = await _Context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {
            _Context.Students.Add(student);
            await _Context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetStudentById), new { id = student.StudentID }, student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] Student student)
        {
            var existingStudent = _Context.Students.Find(id);
            if (existingStudent == null)
            {
                return NotFound();
            }
            existingStudent.StudentName = student.StudentName;
            existingStudent.StudentSurname = student.StudentSurname;
            existingStudent.StudentGender = student.StudentGender;
            existingStudent.DOB = student.DOB;
            existingStudent.StudentEmail = student.StudentEmail;
            existingStudent.StudentPhone = student.StudentPhone;
            existingStudent.StudentAddress = student.StudentAddress;
            existingStudent.EnrollmentDate = student.EnrollmentDate;
            await _Context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = _Context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            _Context.Students.Remove(student);
            await _Context.SaveChangesAsync();
            return NoContent();
        }
    }
}