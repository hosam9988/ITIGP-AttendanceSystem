using AutoMapper;
using Contracts;
using Contracts.ServicesContracts;
using Domain.Dtos;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class TrackActionServices : ITrackActionServices
    {
        private readonly IAppRepositoryManager _repositoryManager;
        private IMapper _mapper;
        public TrackActionServices(IAppRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
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

        public async Task<TrackActionReadDto> GetTrackAction(int trackId, int id)
        {
            var trackAction = await _repositoryManager.TrackActionRepository.GetTrackActionAsync(trackId, id, false);
            var trackActionEntity = _mapper.Map<TrackActionReadDto>(trackAction);
            return trackActionEntity;
        }

        public async Task<List<TrackActionReadDto>> GetTrackActionsForTrack(int trackId)
        {
            var trackActions = await _repositoryManager.TrackActionRepository.GetTrackActions(trackId, false);
            var trackActionEntities = _mapper.Map<List<TrackActionReadDto>>(trackActions);
            return trackActionEntities;
        }

        public async Task Update(int trackId, int id, TrackAction Track)
        {
            var trackAction = await _repositoryManager.TrackActionRepository.GetTrackActionAsync(trackId, id, true);
            _repositoryManager.TrackActionRepository.UpdateTrackAction(trackAction);
            await _repositoryManager.SaveAsync();
        }
    }
}
