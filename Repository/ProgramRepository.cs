using Contracts.RepositoryContracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProgramRepository : AppRepository<Program>, IProgramRepository
    {
        public ProgramRepository(ITIAttendanceContext context) : base(context)
        {
        }

        public Program CreateProgram(Program program)
        {
            Create(program);
            return program;
        }

        public void DeleteProgram(Program program) => Delete(program);


        public async Task<List<Program>> GetAllPrograms(bool trackChanges) => await FindAll(trackChanges:false).ToListAsync();



        public async Task<Program> GetProgramAsync(int programId, bool trackChanges) =>
            await FindByCondition(p => p.Id == programId, trackChanges).SingleOrDefaultAsync();
        
    }
}
