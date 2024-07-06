using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTO.StudentDTO;
using api.Interfaces;
using api.Mappers;
using api.Model;
using api.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
     
        private readonly IStudentRepository _StudentRepository;
        public StudentController(IStudentRepository StudentRepository)
        {
            _StudentRepository = StudentRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _StudentRepository.GetStudentsAsync();
            var studentDTOs = students.Select(x => x.ToStudentListDTOs()).ToList();
            return Ok(studentDTOs);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetStudentById([FromRoute] int id)
        {
            var student = await _StudentRepository.GetStudentByIdAsync(id);
            return Ok(student.ToStudentListDTOs());
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] StudentCreateDTO studentDTO)
        {
            var StudentModel = studentDTO.ToCreateStudentDTO();
            await _StudentRepository.AddStudentAsync(StudentModel);
            return CreatedAtAction(nameof(GetStudentById), new { id = StudentModel.StudentID }, StudentModel.ToStudentListDTOs());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateStudent([FromRoute] int id, [FromBody] StudentUpdateDTO studentDTO)
        {
            var existingStudent = await _StudentRepository.UpdateStudentAsync(id, studentDTO);
            return Ok(existingStudent.ToStudentListDTOs());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] int id)
        {
            await _StudentRepository.DeleteStudentAsync(id);
            return NoContent();
        }
    }
}