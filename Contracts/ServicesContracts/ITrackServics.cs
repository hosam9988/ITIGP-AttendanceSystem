using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ServicesContracts
{
    public interface ITrackServices
    {
        Task Create(int ProgramId, Track track);
        Task Update(int programId, int id, Track track);
        Task Delete(int programId, int id);
        Task<Track> GetTrack(int programId, int id);
        Task<List<Track>> GetTracksForProgram(int programId);
    }
}
