using Contracts.ServicesContracts;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
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
        public async Task AddProgram([FromBody] ProgramManipulationDto program)
        {
            await _manager.ProgramServices.Create(program);
        }
        #endregion

        #region Read
        [HttpGet]
        public async Task<IActionResult> GetPrograms()
        {
            var programs = await _manager.ProgramServices.GetPrograms();
            return  programs == null ? NotFound() :  Ok(programs);
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
            await _manager.ProgramServices.Update(programId, program);
            return NoContent();
        }
        #endregion

        #region Delete
        [HttpDelete("{programId}")]

        public async Task<IActionResult> DeleteProgram(int programId)
        {
            await _manager.ProgramServices.Delete(programId);
            return NoContent();
        }
        #endregion
    }
}
