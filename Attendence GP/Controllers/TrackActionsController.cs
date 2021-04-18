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
    [Route("track/{trackId}/[controller]")]
    [ApiController]
    public class TrackActionsController : ControllerBase
    {

        private readonly IServicesManager _manager;

        public TrackActionsController(IServicesManager manager)
        {
            _manager = manager;
        }

        [HttpPost]
        public async Task AddTrackActionForTrack(int trackId, [FromBody] TrackActionManipulationDto trackAction)
        {
            await _manager.TrackActionServices.Create(trackId, trackAction);
        }

        [HttpGet]
        public async Task<IActionResult> GetTrackActionsForTrack(int trackId)
        {
            var trackActions = await _manager.TrackActionServices.GetTrackActionsForTrack(trackId);
            return Ok(trackActions);
        }
        [HttpGet("{trackActionId}")]
        public async Task<IActionResult> GetTrackActionsById(int trackId, int trackActionId)
        {

            var trackAction = await _manager.TrackActionServices.GetTrackAction(trackId, trackActionId);
            return Ok(trackAction);
        }

        [HttpPut("{trackActionId}")]

        public async Task<IActionResult> UpdateTrackActionForTrack(int trackId, int trackActionId, [FromBody] TrackActionManipulationDto trackAction)
        {
            await _manager.TrackActionServices.Update(trackId, trackActionId, trackAction);
            return NoContent();
        }

        [HttpDelete("{trackActionId}")]

        public async Task<IActionResult> DeleteTRackActionForTrack(int trackId, int trackActionId)
        {
            await _manager.TrackActionServices.Delete(trackId, trackActionId);
            return NoContent();
        }
    }
}
