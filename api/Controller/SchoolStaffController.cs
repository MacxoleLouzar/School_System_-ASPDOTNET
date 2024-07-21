using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.SchoolStaffDTO;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchoolStaffController : ControllerBase
    {
        private readonly ISchoolStaffRepository _schoolStaffRepository;
        private readonly IDepartmentRepository _departmentRepository;
        public SchoolStaffController(ISchoolStaffRepository schoolStaffRepository, IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
            _schoolStaffRepository = schoolStaffRepository;
        }

       

        [HttpGet]
        public async Task<IActionResult> GetAllSchoolStaff()
        {
            try
            {
                
                var schoolStaff = await _schoolStaffRepository.GetAllAsync();
                var schoolStaffDTO = schoolStaff.Select(s => s.ToSchoolStaffDTO()).ToList();
                return Ok(schoolStaffDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSchoolStaff([FromRoute] int id)
        {
            try
            {
                var schoolStaff = await _schoolStaffRepository.GetByIdAsync(id);
                if (schoolStaff == null)
                {
                    return NotFound("School Staff not found");
                }
                return Ok(schoolStaff.ToSchoolStaffDTO());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

         [HttpPost]
        public async Task<IActionResult> AddSchoolStaff([FromRoute]int departmentId, [FromBody] SchoolStaffFromCreateDTO schoolStaffDTO)
        {
            try
            {
                var department = await _departmentRepository.DepartmentExists(departmentId);
                if (!department)
                {
                    return NotFound("Department not found");
                }
                var StaffDTO = schoolStaffDTO.ToSchoolStaffFromCreateDTO(departmentId);
                var newSchoolStaff = await _schoolStaffRepository.CreateAsync(StaffDTO);
                return CreatedAtAction(nameof(GetSchoolStaff), new { id = newSchoolStaff.staffId }, newSchoolStaff.ToSchoolStaffDTO());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSchoolStaff([FromRoute]int id, [FromBody] SchoolStaffFromUpdateDTO schoolStaffDTO)
        {
            try
            {
                var schoolStaff = await _schoolStaffRepository.GetByIdAsync(id);
                if (schoolStaff == null)
                {
                    return NotFound("School Staff not found");
                }
                var schoolDTO = schoolStaffDTO.ToSchoolStaffFromUpdateDTO(id);
                var updatedSchoolStaff = await _schoolStaffRepository.UpdateAsync(id, schoolDTO);
                return Ok(schoolDTO.ToSchoolStaffDTO());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchoolStaff([FromRoute] int id)
        {
            try
            {
                var schoolStaff = await _schoolStaffRepository.GetByIdAsync(id);
                if (schoolStaff == null)
                {
                    return NotFound("School Staff not found");
                }
                await _schoolStaffRepository.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}