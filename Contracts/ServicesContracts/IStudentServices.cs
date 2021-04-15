using Domain.Dtos;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.ServicesContracts
{
    public interface IStudentServices
    {
        Task Create(int trackActionId, Student student);
        Task Update( int id, StudentUpdateDto student);
        Task Delete(int id);
        Task<StudentReadDto> GetStudent(int id);
        Task<List<StudentReadDto>> GetStudentsForTrack(int trackActionId);
        Task<List<Student>> GetStudents(int trackActionId);
    }
}
