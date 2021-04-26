using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RepositoryContracts
{
    public interface IProgramRepository
    {
        Task<List<Program>> GetAllPrograms(bool trackChanges);
        Task<Program> GetProgramAsync(int programId, bool trackChanges);
        Program CreateProgram(Program program);
        void DeleteProgram(Program program);
    }
}
