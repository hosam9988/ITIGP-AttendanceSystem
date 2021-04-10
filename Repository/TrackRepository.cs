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

        public void CreateTrack(Track track) => Create(track);


        public void DeleteTrack(Track track) => Delete(track);


        public Task<Track> GetTrackAsync(int track, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<List<Track>> GetTracks(bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public void UpdateTrack(Track track)
        {
            throw new NotImplementedException();
        }
    }
}
