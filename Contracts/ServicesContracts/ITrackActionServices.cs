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
        Task Create(int trackId, TrackAction trackAction);
        Task Update(int trackId, int id, TrackAction Track);
        Task Delete(int trackId, int id);
        Task<TrackAction> GetTrackAction(int trackId, int id);
        Task<List<TrackAction>> GetTrackActionsForTrack(int trackId);
    }
}
