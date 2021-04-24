using Contracts.ServicesContracts;
using Domain.Dtos;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ServiceBus.Messaging;
using System;
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

            try
            {
                var program = await _manager.ProgramServices.GetProgram(programId);
                var tr = await _manager.TrackServices.Create(programId, track);
                return Created("Track Created Successfully", tr);
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

        #region Read

        [HttpGet("{programId}/[controller]")]
        public async Task<IActionResult> GetTracksForProgram(int programId)
        {
            var tracks = await _manager.TrackServices.GetTracksForProgram(programId);

            return tracks.Count == 0 ? NotFound() : Ok(tracks);
        }

        [HttpGet("[controller]/{trackId}")]
        public async Task<IActionResult> GetTrackForProgram(int trackId)
        {
            var track = await _manager.TrackServices.GetTrack(trackId);

            return track == null ? NotFound() : Ok(track);

        }

        #endregion Read

        [HttpPut("[controller]/{trackId}")]
        public async Task<IActionResult> UpdateTrackForProgram(int trackId, [FromBody] TrackManipulationDto track)
        {
            try
            {
                await _manager.TrackServices.Update(trackId, track);
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

        [HttpDelete("[controller]/{trackId}")]
        public async Task<IActionResult> DeleteTrackForProgram(int trackId)
        {
            try
            {
                await _manager.TrackServices.Delete(trackId);
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
    }
}