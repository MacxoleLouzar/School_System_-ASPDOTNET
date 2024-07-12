using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.StreamDTO;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class StreamController : ControllerBase
    {
        private readonly IStreamRepository _streamService;
        public StreamController(IStreamRepository streamService){
            _streamService = streamService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllStreams(){

            if( ModelState.IsValid == false ){
                return BadRequest(ModelState);
            }
            var stream = await _streamService.GetAllStreamsAsync();
            var streamDto = stream.Select(x => x.ToStreamListDTO()).ToList();
            return Ok(streamDto);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetStreamById(int id){
            if( ModelState.IsValid == false ){
                return BadRequest(ModelState);
            }
            var stream = await _streamService.GetStreamByIdAsync(id);
            return Ok(stream.ToStreamListDTO());
        }

        [HttpPost]
        public async Task<IActionResult> CreateStream([FromBody] CreateStreamDTO stream){
            if( ModelState.IsValid == false ){
                return BadRequest(ModelState);
            }
            var streamModel = stream.ToCreateStreamDTO();
            await _streamService.CreateStreamAsync(streamModel);
            return CreatedAtAction(nameof(GetStreamById), new {id = streamModel.StreamId}, streamModel.ToStreamListDTO());
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStream([FromRoute]int id, [FromBody] UpdateStreamDTO stream){
            if( ModelState.IsValid == false ){
                return BadRequest(ModelState);
            }
            var streamModel = stream.ToUpdateStreamDTO();
           var streamUpdate = await _streamService.UpdateStreamAsync(id, streamModel);
           if (streamUpdate == null){
               return NotFound();
           }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStream(int id){
            if( ModelState.IsValid == false ){
                return BadRequest(ModelState);
            }
           var stream = await _streamService.DeleteStreamAsync(id);
           if (stream == null){
               return NotFound();
           }
            return NoContent();
        }

    }
}