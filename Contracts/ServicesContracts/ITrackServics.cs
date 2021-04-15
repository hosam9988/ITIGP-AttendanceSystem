using Domain.Dtos;
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
        Task Create(int ProgramId, TrackManipulationDto track);
        Task Update(int programId, int id, TrackManipulationDto track);
        Task Delete(int programId, int id);
        Task<TrackReadDto> GetTrack(int programId, int id);
        Task<List<TrackReadDto>> GetTracksForProgram(int programId);
    }
}
