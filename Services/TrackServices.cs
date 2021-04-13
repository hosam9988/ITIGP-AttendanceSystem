using AutoMapper;
using Contracts;
using Contracts.ServicesContracts;
using Domain.Dtos;
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
        private IMapper _mapper;
        public TrackServices(IAppRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
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

        public async Task<TrackReadDto> GetTrack(int programId, int id) {
            var track = await _repositoryManager.TrackRepository.GetTrackAsync(programId, id, false);
            var trackEntity = _mapper.Map<TrackReadDto>(track);
            return trackEntity;
        }


        public async Task<List<TrackReadDto>> GetTracksForProgram(int programId)
        {
            var tracks = await _repositoryManager.TrackRepository.GetTracks(programId, false);
            var trackEntities = _mapper.Map<List<TrackReadDto>>(tracks);
            return trackEntities;    
        }

        public async Task Update(int programId, int id, TrackUpdateDto track)
        {
            var trackEntity = await _repositoryManager.TrackRepository.GetTrackAsync(programId, id, true);
            _mapper.Map(track, trackEntity);
            _repositoryManager.TrackRepository.UpdateTrack(trackEntity);
            await _repositoryManager.SaveAsync();
        }
    }
}
