using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.EnrollmentDTO;
using api.Interfaces;
using api.Mappers;
using api.Model;
using Microsoft.AspNetCore.Mvc;

namespace api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentController : ControllerBase
    {
         private readonly IEnrollmentRepository _enrollmentRepository;

         public EnrollmentController(IEnrollmentRepository enrollmentRepository)
         {
            _enrollmentRepository = enrollmentRepository;
         }

         [HttpGet]
         public async Task<IActionResult> GetAllEnrollment()
         {
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var enroll = await _enrollmentRepository.GetAllEnrollmentsAsync();
            var enrollDTO = enroll.Select(e => e.ToEnrollmentListDTO()).ToList();
            return Ok(enrollDTO);
         }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEnrollmentByIdAsync(int id)
        {
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var enrollment = await _enrollmentRepository.GetEnrollmentsByID(id);
            if(enrollment == null){
                return NotFound();
            }
            return Ok(enrollment);
        }


        [HttpPost]
        public async Task<IActionResult> CreateEnrollment([FromBody] EnrollmentCreateDTO createDTO)
        {
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var enrollment = createDTO.ToEnrollmentFromCreateDTO();
            await _enrollmentRepository.CreateEnrollmentAsync(enrollment);
            return CreatedAtAction(nameof(GetEnrollmentByIdAsync), new {id = enrollment.EnrollmentID}, enrollment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEnrollment([FromRoute]int id, [FromBody] EnrollmentUpdateDTO updateDTO)
        {
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var enrollment = await _enrollmentRepository.GetEnrollmentsByID(id);
            if(enrollment == null){
                return NotFound();
            }
           var enrollmentDTO = updateDTO.ToEnrollmentFromUpdateDTO();
           await _enrollmentRepository.UpdateEnrollmentAsync(id, enrollmentDTO);
           return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnrollment(int id)
        {
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var enrollment = await _enrollmentRepository.GetEnrollmentsByID(id);
            if(enrollment == null){
                return NotFound();
            }
            await _enrollmentRepository.DeleteEnrollmentAsync(id);
            return NoContent();
        }
    }
}