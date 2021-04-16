using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RepositoryContracts
{
    public interface IAttendanceRepository
    {
        Task<List<Student>> GetStudentsForAttendance(int trackActionId);
        Task<Attendance> GetAttendanceForStudent(int studentId, DateTime date, bool trackChanges);
        Task<Attendance> GetAttendanceForTrack(int trackActionId, DateTime date, bool trackChanges);
        void CreateTrackAttendance(int studentId, Attendance attendance);
        void DeleteAttendance(Attendance attendance);
    }
}
