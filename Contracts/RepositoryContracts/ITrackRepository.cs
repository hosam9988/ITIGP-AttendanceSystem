using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ITrackRepository
    {
        Task<List<Track>> GetTracks(int programId, bool trackChanges);
        Task<Track> GetTrackAsync(int programId, int track, bool trackChanges);
        void CreateTrack(int programId,Track track);
        void DeleteTrack(Track track);
        void UpdateTrack(Track track);
    }
}
