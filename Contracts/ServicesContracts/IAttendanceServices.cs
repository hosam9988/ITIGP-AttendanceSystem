using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ServicesContracts
{
    public interface IAttendanceServices
    {
        Task Create(int studentId, AttendanceManipulationDto attendance);
        Task Update(int studentId, DateTime date, AttendanceManipulationDto attendance);
        Task Delete(int studentId, DateTime date);
        Task<StudentAttendanceReadDto> GetAttendanceForStudent(int studentId, DateTime date);
        Task<List<StudentAttendanceReadDto>> GetAttendanceForTrack(int trackActionId, DateTime date);
        Task<List<StudentAttendanceReadDto>> GetAllAttendances(int trackActionId);
    }
}
