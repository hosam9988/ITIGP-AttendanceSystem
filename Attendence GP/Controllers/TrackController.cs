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
    [Route("programs/{programId}/[controller]")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        private readonly ITrackServices _trackServices;
        public TrackController(ITrackServices trackServices)
        {
            _trackServices = trackServices;
        }

        [HttpPost]
        public async Task AddTrack(int programId, [FromBody] Track track)
        {
            await _trackServices.Create(programId, track);
        }

    }
}
