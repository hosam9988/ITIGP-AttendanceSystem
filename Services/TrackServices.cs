using Contracts;
using Contracts.ServicesContracts;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TrackServices : ITrackServices
    {
        private readonly IAppRepositoryManager _repositoryManager;
        public TrackServices(IAppRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task Create(int ProgramId, Track track)
        {
             _repositoryManager.TrackRepository.CreateTrack(ProgramId, track);
            await _repositoryManager.SaveAsync();
        }

        public async Task Delete(int programId, int id)
        {
            var track = await _repositoryManager.TrackRepository.GetTrackAsync(programId, id, false);
            _repositoryManager.TrackRepository.DeleteTrack(track);
            await _repositoryManager.SaveAsync();
        }

        public async Task<Track> GetTrack(int programId, int id) =>
            await _repositoryManager.TrackRepository.GetTrackAsync(programId, id, false);
        

        public async Task<List<Track>> GetTracksForProgram(int programId)=>
              await _repositoryManager.TrackRepository.GetTracks(programId, false);


        public async Task Update(int programId, int id, Track track)
        {
            var track1 = await _repositoryManager.TrackRepository.GetTrackAsync(programId, id, true);
            _repositoryManager.TrackRepository.UpdateTrack(track1);
            await _repositoryManager.SaveAsync();

        }
    }
}
