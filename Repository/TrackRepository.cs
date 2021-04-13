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
    public class TrackRepository : AppRepository<Track>, ITrackRepository
    {
        public TrackRepository(ITIAttendanceContext context) : base(context)
        {
        }

        

        public void CreateTrack(int programId, Track track)
        {
            track.ProgramId = programId;
            Create(track);
        }

        public void DeleteTrack(Track track) => Delete(track);


        public Task<Track> GetTrackAsync(int track, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public async Task<Track> GetTrackAsync(int programId, int trackId, bool trackChanges) =>
            await FindByCondition(e => e.ProgramId == programId && e.Id == trackId, trackChanges).SingleOrDefaultAsync();


        public async Task<List<Track>> GetTracks(int programId, bool trackChanges) =>
            await FindByCondition(e => e.ProgramId == programId, trackChanges).ToListAsync();


        public void UpdateTrack(Track track) => Update(track);
       

    }
}
