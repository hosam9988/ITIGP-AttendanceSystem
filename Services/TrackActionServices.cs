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
    public class TrackActionServices : ITrackActionServices
    {
        private readonly IAppRepositoryManager _repositoryManager;
        public TrackActionServices(IAppRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task Create(int trackId, TrackAction trackAction)
        {
            _repositoryManager.TrackActionRepository.CreateTrackAction(trackId, trackAction);
            await _repositoryManager.SaveAsync();
        }

        public async Task Delete(int trackId, int id)
        {
            var trackAction = await _repositoryManager.TrackActionRepository.GetTrackActionAsync(trackId, id, false);
            _repositoryManager.TrackActionRepository.DeleteTrackAction(trackAction);
            await _repositoryManager.SaveAsync();
        }

        public async Task<TrackAction> GetTrackAction(int trackId, int id)
        {
           return await _repositoryManager.TrackActionRepository.GetTrackActionAsync(trackId, id,false);
        }

        public async Task<List<TrackAction>> GetTrackActionsForTrack(int trackId)
        {
            return await _repositoryManager.TrackActionRepository.GetTrackActions(trackId, false);
        }

        public async Task Update(int trackId, int id, TrackAction Track)
        {
            var trackAction = await _repositoryManager.TrackActionRepository.GetTrackActionAsync(trackId, id, true);
            _repositoryManager.TrackActionRepository.UpdateTrackAction(trackAction);
            await _repositoryManager.SaveAsync();
        }
    }
}
