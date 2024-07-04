using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTO.StudentDTO;
using api.Mappers;
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
            var students = _Context.Students.ToList().Select(x => x.ToStudentListDTOs());
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
            return Ok(student.ToStudentListDTOs());
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] StudentCreateDTO studentDTO)
        {
            var StudentModel = studentDTO.ToCreateStudentDTO();
            _Context.Students.Add(StudentModel);
            await _Context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetStudentById), new { id = StudentModel.StudentID }, StudentModel.ToStudentListDTOs());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent([FromRoute]int id, [FromBody] StudentUpdateDTO studentDTO)
        {
            var existingStudent = _Context.Students.Find(id);
            if (existingStudent == null)
            {
                return NotFound();
            }
            existingStudent.StudentName = studentDTO.StudentName;
            existingStudent.StudentSurname = studentDTO.StudentSurname;
            existingStudent.StudentGender = studentDTO.StudentGender;
            existingStudent.DOB = studentDTO.DOB;
            existingStudent.StudentEmail = studentDTO.StudentEmail;
            existingStudent.StudentPhone = studentDTO.StudentPhone;
            existingStudent.StudentAddress = studentDTO.StudentAddress;
            existingStudent.EnrollmentDate = studentDTO.EnrollmentDate;
            await _Context.SaveChangesAsync();
            return Ok(existingStudent.ToStudentListDTOs());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent([FromRoute]int id)
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