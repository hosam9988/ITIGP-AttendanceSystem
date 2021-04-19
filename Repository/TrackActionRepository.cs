using Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class TrackActionRepository : AppRepository<TrackAction>, ITrackActionRepository
    {
        public TrackActionRepository(ITIAttendanceContext context) : base(context)
        {
        }

        public void CreateTrackAction(int trackId, TrackAction trackAction)
        {
            trackAction.TrackId = trackId;
            Create(trackAction);
        }

        public void DeleteTrackAction(TrackAction trackAction) => Delete(trackAction);

        public async Task<TrackAction> GetTrackActionAsync(int id, bool trackChanges) =>
            await FindByCondition(e =>e.Id == id, trackChanges).Include(tr => tr.Track).SingleOrDefaultAsync();

        public async Task<List<TrackAction>> GetTrackActions(int trackId, bool trackChanges) =>
            await FindByCondition(e => e.TrackId == trackId, trackChanges).Include(tr=>tr.Track).ToListAsync();

       //public void UpdateTrackAction(TrackAction trackAction) => Update(trackAction);

    }
}
