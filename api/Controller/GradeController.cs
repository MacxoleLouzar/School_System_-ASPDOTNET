using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.GradeDTO;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;


namespace api.Controller
{
    [Route("[controller]")]
    public class GradeController : ControllerBase
    {
        private readonly IGradeRepository _gradeRepository;

        public GradeController(IGradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGrades()
        {
            var grades = await _gradeRepository.GetGradesAsync();
            var gradeDTO = grades.Select( x => x.ToReadGradeDto()).ToList();
            return Ok(gradeDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGradeById(int id)
        {
            var grade = await _gradeRepository.GetGradeByIdAsync(id);
            if (grade == null)
            {
                return NotFound();
            }
            return Ok(grade.ToReadGradeDto());
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateGrade([FromBody] GradeCreateDTO createGradeDto)
        {
            var grade = createGradeDto.ToCreateGradeDto();
            await _gradeRepository.CreateGradeAsync(grade);
            return CreatedAtAction(nameof(GetGradeById), new { id = grade.GradeId }, grade.ToReadGradeDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGrade(int id, [FromBody] GradeUpdateDTO updateGradeDto)
        {
            var existingGrade = await _gradeRepository.GetGradeByIdAsync(id);
            if (existingGrade == null)
            {
                return NotFound();
            }

            var grade = updateGradeDto.ToEditGradeDto();
            await _gradeRepository.UpdateGradeAsync(id, grade);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrade(int id)
        {
            var existingGrade = await _gradeRepository.GetGradeByIdAsync(id);
            if (existingGrade == null)
            {
                return NotFound();
            }

            await _gradeRepository.DeleteGradeAsync(id);
            return NoContent();
        }
    }
}