using Domain.Dtos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ServicesContracts
{
    public interface ITrackActionServices
    {
        Task<TrackActionReadDto> Create(int trackId, TrackActionManipulationDto trackAction);
        Task Update(int id, TrackActionManipulationDto trackAction);
        Task Delete(int id);
        Task<TrackActionReadDto> GetTrackAction(int id);
        Task<List<TrackActionReadDto>> GetTrackActionsForTrack(int trackId);
    }
}
