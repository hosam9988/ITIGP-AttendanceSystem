using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ServicesContracts
{
    public interface IProgramServices
    {
        Task Create(ProgramManipulationDto program);
        Task Update(int programId, ProgramManipulationDto program);
        Task Delete(int programId);
        Task<ProgramReadDto> GetProgram(int programId);
        Task<List<ProgramReadDto>> GetPrograms();
    }
}
