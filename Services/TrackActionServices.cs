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
        private readonly IMapper _mapper;
        public TrackActionServices(IAppRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task Create(int trackId, TrackActionManipulationDto trackAction)
        {
            var trackActionEntity = _mapper.Map<TrackAction>(trackAction);
            _repositoryManager.TrackActionRepository.CreateTrackAction(trackId, trackActionEntity);
            await _repositoryManager.SaveAsync();
        }

        public async Task Delete(int id)
        {
            var trackAction = await _repositoryManager.TrackActionRepository.GetTrackActionAsync(id, false);
            _repositoryManager.TrackActionRepository.DeleteTrackAction(trackAction);
            await _repositoryManager.SaveAsync();
        }

        public async Task<TrackActionReadDto> GetTrackAction(int id)
        {
            var trackAction = await _repositoryManager.TrackActionRepository.GetTrackActionAsync(id, false);
            var trackActionEntity = _mapper.Map<TrackActionReadDto>(trackAction);
            return trackActionEntity;
        }

        public async Task<List<TrackActionReadDto>> GetTrackActionsForTrack(int trackId)
        {
            var trackActions = await _repositoryManager.TrackActionRepository.GetTrackActions(trackId, false);
            var trackActionEntities = _mapper.Map<List<TrackActionReadDto>>(trackActions);
            return trackActionEntities;
        }

        public async Task Update(int id, TrackActionManipulationDto trackAction)
        {
            var trackActionEntity = await _repositoryManager.TrackActionRepository.GetTrackActionAsync(id, true);
            _mapper.Map(trackAction, trackActionEntity);
            await _repositoryManager.SaveAsync();
        }
    }
}
