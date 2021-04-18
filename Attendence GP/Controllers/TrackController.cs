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
        public async Task AddTrackToProgram(int programId, [FromBody] TrackManipulationDto track)
        {
            await _manager.TrackServices.Create(programId, track);
        }

        #region Read

        [HttpGet("{programId}/[controller]")]
        public async Task<IActionResult> GetTracksForProgram(int programId)
        {
            var tracks = await _manager.TrackServices.GetTracksForProgram(programId);
            return Ok(tracks);
        }

        [HttpGet("{programId}/[controller]/{trackId}")]
        public async Task<IActionResult> GetTrackForProgram(int programId, int trackId)
        {
            var track = await _manager.TrackServices.GetTrack(programId, trackId);
            return Ok(track);
        }

        #endregion Read

        [HttpPut("{programId}/[controller]/{trackId}")]
        public async Task<IActionResult> UpdateTrackForProgram(int programId, int trackId, [FromBody] TrackManipulationDto track)
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