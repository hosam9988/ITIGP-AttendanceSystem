using Domain.Dtos;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.ServicesContracts
{
    public interface IStudentServices
    {
        Task<StudentReadDto> Create(int trackActionId, int userId, StudentManipulationDto student);
        Task Update(int id, StudentManipulationDto student);
        Task Delete(int id);
        Task<StudentReadDto> GetStudent(int id);
        Task<List<StudentReadDto>> GetStudentsForTrack(int trackActionId);
    }
}
