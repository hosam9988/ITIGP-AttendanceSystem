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
        Task<List<Attendance>> GetAttendances(int trackActionId, bool trackChanges);
        Task<Attendance> GetAttendanceForTrack(int trackActionId, DateTime date, bool trackChanges);
        void CreateTrackAttendance(int trackActionId, Attendance attendance);
        void DeleteAttendanc(Attendance attendance);
        void UpdateAttendanc(Attendance attendance);
    }
}
