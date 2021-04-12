using Contracts.ServicesContracts;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attendence_GP.Controllers
{
    [Route("track/{trackId}/[controller]")]
    [ApiController]
    public class TrackActionsController : ControllerBase
    {

        private readonly ITrackActionServices _trackActionServices;

        public TrackActionsController(ITrackActionServices trackActionServices)
        {
            _trackActionServices = trackActionServices;
        }

        [HttpPost]
        public async Task AddStudent(int trackId, [FromBody] TrackAction trackAction)
        {
            await _trackActionServices.Create(trackId, trackAction);
        }

        [HttpGet]
        public async Task<IActionResult> GetTrackActionsForTrack(int trackId)
        {
            var trackActions = await _trackActionServices.GetTrackActionsForTrack(trackId);
            return Ok(trackActions);
        }
        [HttpGet("{trackActionId}")]
        public async Task<IActionResult> GetTrackActionsPerId(int trackId, int trackActionId)
        {

            var trackAction = await _trackActionServices.GetTrackAction(trackId, trackActionId);
            return Ok(trackAction);
        }

        [HttpPut("{trackActionId}")]

        public async Task<IActionResult> UpdateStudentForTrack(int trackId, int trackActionId, [FromBody] TrackAction trackAction)
        {
            await _trackActionServices.Update(trackId, trackActionId, trackAction);
            return NoContent();
        }

        [HttpDelete("{trackActionId}")]

        public async Task<IActionResult> DeleteStudentForTrack(int trackId, int trackActionId)
        {
            await _trackActionServices.Delete(trackId, trackActionId);
            return NoContent();
        }
    }
}
