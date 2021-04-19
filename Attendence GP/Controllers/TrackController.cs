using Contracts.ServicesContracts;
using Domain.Dtos;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Attendence_GP.Controllers
{
    [Route("programs/")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        private readonly IServicesManager _manager;

        public TrackController(IServicesManager manager)
        {
            _manager = manager;
        }

        [HttpPost("{programId}/[controller]")]
        public async Task<IActionResult> AddTrackToProgram(int programId, [FromBody] TrackManipulationDto track)
        {
            var program = await _manager.ProgramServices.GetProgram(programId);

            if (program != null) {
                await _manager.TrackServices.Create(programId, track);
                return Ok("Successfully added");
            }
            return BadRequest("There's not Program to add Track to ");
        }

        #region Read

        [HttpGet("{programId}/[controller]")]
        public async Task<IActionResult> GetTracksForProgram(int programId)
        {
            var tracks = await _manager.TrackServices.GetTracksForProgram(programId);
            return Ok(tracks);
        }

        [HttpGet("[controller]/{trackId}")]
        public async Task<IActionResult> GetTrackForProgram(int trackId)
        {
            var track = await _manager.TrackServices.GetTrack(trackId);
            return Ok(track);
        }

        #endregion Read

        [HttpPut("[controller]/{trackId}")]
        public async Task<IActionResult> UpdateTrackForProgram(int trackId, [FromBody] TrackManipulationDto track)
        {
            await _manager.TrackServices.Update(trackId, track);
            return NoContent();
        }

        [HttpDelete("[controller]/{trackId}")]
        public async Task<IActionResult> DeleteTrackForProgram(int trackId)
        {
            await _manager.TrackServices.Delete(trackId);
            return NoContent();
        }
    }
}