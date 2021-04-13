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
        private readonly IServicesManager _manager;
        public TrackController(IServicesManager manager)
        {
            _manager = manager;
        }

        [HttpPost]
        public async Task AddTrack(int programId, [FromBody] Track track)
        {
            await _manager.TrackServices.Create(programId, track);
        }

    }
}
