using Contracts.ServicesContracts;
using Domain.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendence_GP.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProgramsController:ControllerBase
    {
        private readonly IServicesManager _manager;

        public ProgramsController(IServicesManager manager)
        {
            _manager = manager;
        }
        #region Create 
        [HttpPost]
        public async Task<IActionResult> AddProgram([FromBody] ProgramManipulationDto program)
        {
            try
            {
                var pro =  await _manager.ProgramServices.Create(program);
                return Created("program created successfully", pro);
            }
            catch (BadHttpRequestException)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "User creation failed! Please check user details and try again." });
            }
        }
        #endregion

        #region Read
        [HttpGet]
        public async Task<IActionResult> GetPrograms()
        {
            var programs = await _manager.ProgramServices.GetPrograms();

            return programs.Count == 0 ? NotFound() : Ok(programs);
        }
        [HttpGet("{programId}")]
        public async Task<IActionResult> GetProgram(int programId)
        {

            var program = await _manager.ProgramServices.GetProgram(programId);
            return program == null ? NotFound() : Ok(program);
        }
        #endregion

        #region update
        [HttpPut("{programId}")]

        public async Task<IActionResult> UpdateProgram(int programId, [FromBody] ProgramManipulationDto program)
        {
            try
            {
                await _manager.ProgramServices.Update(programId, program);
                return NoContent();
            }
            catch (BadHttpRequestException)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "User creation failed! Please check user details and try again." });
            }
        }
        #endregion

        #region Delete
        [HttpDelete("{programId}")]

        public async Task<IActionResult> DeleteProgram(int programId)
        {
            try
            {
                await _manager.ProgramServices.Delete(programId);
                return NoContent();
            }
            catch (BadHttpRequestException)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "User creation failed! Please check user details and try again." });
            }
        }
        #endregion
    }
}
