using Contracts.ServicesContracts;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dtos;
using Microsoft.ServiceBus.Messaging;

namespace Attendence_GP.Controllers
{
    [Route("track/")]
    [ApiController]
    public class TrackActionsController : ControllerBase
    {

        private readonly IServicesManager _manager;

        public TrackActionsController(IServicesManager manager)
        {
            _manager = manager;
        }

        [HttpPost("{trackId}/[controller]")]
        public async Task<IActionResult> AddTrackActionForTrack(int trackId, [FromBody] TrackActionManipulationDto trackAction)
        {
            try
            {
                var tra= await _manager.TrackActionServices.Create(trackId, trackAction);
                return Created("Track Action created successfully", tra);
            }
            catch (BadHttpRequestException)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "Internal server error" });
            }
        }

        [HttpGet("{trackId}/[controller]")]
        public async Task<IActionResult> GetTrackActionsForTrack(int trackId)
        {
            var trackActions = await _manager.TrackActionServices.GetTrackActionsForTrack(trackId);

            return trackActions.Count == 0 ? NotFound() : Ok(trackActions);

        }
        [HttpGet("[controller]/{trackActionId}")]
        public async Task<IActionResult> GetTrackActionsById(int trackActionId)
        {

            var trackAction = await _manager.TrackActionServices.GetTrackAction(trackActionId);

            return trackAction == null ? NotFound() : Ok(trackAction);

        }

        [HttpPut("[controller]/{trackActionId}")]

        public async Task<IActionResult> UpdateTrackActionForTrack(int trackActionId, [FromBody] TrackActionManipulationDto trackAction)
        {
            try
            {
                await _manager.TrackActionServices.Update(trackActionId, trackAction);
                return NoContent();
            }
            catch (BadHttpRequestException)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "Internal server error" });
            }
        }

        [HttpDelete("[controller]/{trackActionId}")]

        public async Task<IActionResult> DeleteTRackActionForTrack(int trackActionId)
        {
            try
            {
                await _manager.TrackActionServices.Delete(trackActionId);
                return NoContent();
            }
            catch (BadHttpRequestException)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "Internal server error" });
            }
        }
    }
}
