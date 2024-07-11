using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.TeacherDTO;
using api.Interfaces;
using api.Mappers;
using api.Model;
using Microsoft.AspNetCore.Mvc;

namespace api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRespository _teacherRespository;
        public TeacherController(ITeacherRespository teacherRespository)
        {
            _teacherRespository = teacherRespository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTeachers()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var teachers = await _teacherRespository.GetTeachersAsync();
            var TeacherList = teachers.Select(x => x.ToTeacherListDTO()).ToList();
            return Ok(TeacherList);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTeacherById(int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var teacher = await _teacherRespository.GetTeacherByIdAsync(id);
            return Ok(teacher.ToTeacherListDTO());
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeacher([FromBody] TeacherCreateDTO addTeacherDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var teacher = addTeacherDTO.ToTeacherCreateDTO();
            await _teacherRespository.CreateTeacherAsync(teacher);
            return CreatedAtAction(nameof(GetTeacherById), new { id = teacher.TeacherId }, teacher);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateTeacher([FromBody] TeacherUpdateDTO teacherUpdateDTO, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var teacher = teacherUpdateDTO.ToTeacherUpdateDTO();
            await _teacherRespository.UpdateTeacherAsync(id, teacher);
            return Ok(teacher);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTeacher([FromRoute] int id)
        {
            var techer = await _teacherRespository.DeleteTeacherAsync(id);
            if (techer == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}