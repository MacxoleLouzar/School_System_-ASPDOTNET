using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.SubjectDTO;
using api.Interfaces;
using api.Mappers;
using api.Model;
using Microsoft.AspNetCore.Mvc;

namespace api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectRespository _subjectrepository;
        public SubjectController( ISubjectRespository subjectrepository)
        {
            _subjectrepository = subjectrepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubjects()
        {
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var subject = await _subjectrepository.GetAllSubjectsAsync();
            var subjectDto = subject.Select(x => x.ToSubjectListDTO()).ToList();
            return Ok(subjectDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubjectById(int id)
        {
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var subject = await _subjectrepository.GetSubjectByIdAsync(id);
            return Ok(subject.ToSubjectListDTO());
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubject([FromBody] SubjectCreateDTO subjectCreateDTO){    
            var subjectDto = subjectCreateDTO.ToSubjectCreateDTO();
            await _subjectrepository.CreateSubjectAsync(subjectDto);
             return CreatedAtAction(nameof(GetSubjectById), new { id = subjectDto.SubjectId }, subjectDto.ToSubjectListDTO());
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSubject([FromRoute]int id, [FromBody] SubjectUpdateDTO subjectUpdateDTO){
             if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var subject = await _subjectrepository.GetSubjectByIdAsync(id);
            var subjectDto = subjectUpdateDTO.ToSubjectUpdateDTO();
            if(subject == null){
                return NotFound();
            }
            await _subjectrepository.UpdateSubjectAsync(id, subjectDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id){
            var subject = await _subjectrepository.GetSubjectByIdAsync(id);
            if(subject == null){
                return NotFound();
            }
            await _subjectrepository.DeleteSubjectAsync(id);
            return NoContent();
        }
    }
}