using AutoMapper;
using Contracts;
using Contracts.ServicesContracts;
using Domain.Dtos;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class TrackServices : ITrackServices
    {
        private readonly IAppRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public TrackServices(IAppRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<TrackReadDto> Create(int ProgramId, TrackManipulationDto track)
        {
            var trackEntityl = _mapper.Map<Track>(track);
           var tra= _repositoryManager.TrackRepository.CreateTrack(ProgramId, trackEntityl);
            await _repositoryManager.SaveAsync();

            return _mapper.Map<TrackReadDto>(tra);
        }

        public async Task Delete(int id)
        {
            var track = await _repositoryManager.TrackRepository.GetTrackAsync( id, false);
            _repositoryManager.TrackRepository.DeleteTrack(track);
            await _repositoryManager.SaveAsync();
        }

        public async Task<TrackReadDto> GetTrack(int id)
        {
            var track = await _repositoryManager.TrackRepository.GetTrackAsync(id, false);
            var trackEntity = _mapper.Map<TrackReadDto>(track);
            return trackEntity;
        }


        public async Task<List<TrackReadDto>> GetTracksForProgram(int programId)
        {
            var tracks = await _repositoryManager.TrackRepository.GetTracks(programId, false);
            var trackEntities = _mapper.Map<List<TrackReadDto>>(tracks);
            return trackEntities;
        }

        public async Task Update(int id, TrackManipulationDto track)
        {
            var trackEntity = await _repositoryManager.TrackRepository.GetTrackAsync(id, true);
            _mapper.Map(track, trackEntity);
            await _repositoryManager.SaveAsync();
        }
    }
}
