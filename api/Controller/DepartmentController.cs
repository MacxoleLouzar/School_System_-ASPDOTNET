using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.DepartmentDTO;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            
            var departments = await _departmentRepository.GetAllAsync();
            var DepartDTO = departments.Select(x => x.ToDepartmentDTO()).ToList();
            return Ok(DepartDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department.ToDepartmentDTO());
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody] DepartCreateDTO departmentDTO)
        {
            var department = departmentDTO.ToDpartmentFromCreateDTO();
            await _departmentRepository.CreateAsync(department);
            return CreatedAtAction(nameof(GetDepartmentById), new { id = department.departmentId }, department.ToDepartmentDTO());
        }

        // [HttpPut("{id}")]
        // public async Task<IActionResult> UpdateDepartment([FromRoute] int id,[FromBody] DepartUpdateDTO departmentDTO)
        // {
        //     var existingDepartment = await _departmentRepository.GetByIdAsync(id);
        //     if (existingDepartment == null)
        //     {
        //         return NotFound();
        //     }

        //     existingDepartment = departmentDTO.ToDepartmentFromUpdateDTO(existingDepartment);
            
        //     await _departmentRepository.UpdateAsync(id, existingDepartment);
        //     return Ok(existingDepartment.ToDepartmentDTO());
        // }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, [FromBody] DepartUpdateDTO departmentDTO)
        {
            var existingDepartment = await _departmentRepository.GetByIdAsync(id);
            if (existingDepartment == null)
            {
                return NotFound();
            }

            existingDepartment = departmentDTO.ToDepartmentFromUpdateDTO(existingDepartment);
            await _departmentRepository.UpdateAsync(id, existingDepartment);
            return Ok(existingDepartment.ToDepartmentDTO());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var existingDepartment = await _departmentRepository.GetByIdAsync(id);
            if (existingDepartment == null)
            {
                return NotFound();
            }

            await _departmentRepository.DeleteAsync(id);
            return NoContent();
        }
    
    }
}