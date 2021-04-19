using Contracts.ServicesContracts;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dtos;

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
        public async Task AddTrackActionForTrack(int trackId, [FromBody] TrackActionManipulationDto trackAction)
        {
            await _manager.TrackActionServices.Create(trackId, trackAction);
        }

        [HttpGet("{trackId}/[controller]")]
        public async Task<IActionResult> GetTrackActionsForTrack(int trackId)
        {
            var trackActions = await _manager.TrackActionServices.GetTrackActionsForTrack(trackId);
            return Ok(trackActions);
        }
        [HttpGet("[controller]/{trackActionId}")]
        public async Task<IActionResult> GetTrackActionsById(int trackActionId)
        {

            var trackAction = await _manager.TrackActionServices.GetTrackAction(trackActionId);
            return Ok(trackAction);
        }

        [HttpPut("[controller]/{trackActionId}")]

        public async Task<IActionResult> UpdateTrackActionForTrack(int trackActionId, [FromBody] TrackActionManipulationDto trackAction)
        {
            await _manager.TrackActionServices.Update(trackActionId, trackAction);
            return NoContent();
        }

        [HttpDelete("[controller]/{trackActionId}")]

        public async Task<IActionResult> DeleteTRackActionForTrack(int trackActionId)
        {
            await _manager.TrackActionServices.Delete(trackActionId);
            return NoContent();
        }
    }
}
