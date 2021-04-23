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
    public class ProgramServices : IProgramServices
    {
        private readonly IAppRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ProgramServices(IAppRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<ProgramReadDto> Create( ProgramManipulationDto program)
        {
            var programEntity = _mapper.Map<Program>(program);
           var pro = _repositoryManager.ProgramRepository.CreateProgram(programEntity);
            await _repositoryManager.SaveAsync();
            return _mapper.Map<ProgramReadDto>(pro);
        }

        public async Task Delete(int programId)
        {
            var program = await _repositoryManager.ProgramRepository.GetProgramAsync(programId, false);
            _repositoryManager.ProgramRepository.DeleteProgram(program);
            await _repositoryManager.SaveAsync();
        }

        public async Task<ProgramReadDto> GetProgram(int programId)
        {
            var program = await _repositoryManager.ProgramRepository.GetProgramAsync(programId, trackChanges: false);
            var programEntity = _mapper.Map<ProgramReadDto>(program);
            return programEntity;
        }

        public async Task<List<ProgramReadDto>> GetPrograms()
        {
            var programs = await _repositoryManager.ProgramRepository.GetAllPrograms(trackChanges: false);
            return _mapper.Map<List<ProgramReadDto>>(programs);
        }

        public async Task Update(int programId, ProgramManipulationDto program)
        {
            var programEntity = await _repositoryManager.ProgramRepository.GetProgramAsync(programId, trackChanges: true);
            _mapper.Map(program, programEntity);
            await _repositoryManager.SaveAsync();
        }
    }
}
