using Contracts;
using Domain.Models;
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

        public Task<Track> GetTrackAsync(int programId, int track, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<List<Track>> GetTracks(int programId, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public void UpdateTrack(Track track)
        {
            throw new NotImplementedException();
        }

    }
}
