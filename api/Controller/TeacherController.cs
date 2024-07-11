using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
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
            var teachers = await _teacherRespository.GetTeachersAsync();
            return Ok(teachers);
        }  
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTeacherById(int id)
        {
            var teacher = await _teacherRespository.GetTeacherByIdAsync(id);
            return Ok(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeacher([FromBody] Teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _teacherRespository.CreateTeacherAsync(teacher);
            return CreatedAtAction(nameof(GetTeacherById), new { id = teacher.TeacherId }, teacher);
        }
    }
}