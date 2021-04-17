using Contracts.RepositoryContracts;
using System.Threading.Tasks;

namespace Contracts
{
    //Unit Of Work DP 
    public interface IAppRepositoryManager
    {
        IStudentRepository StudentRepository { get; }
        ITrackActionRepository TrackActionRepository { get; }
        ITrackRepository TrackRepository { get; }
        IPermissionRepository PermissionRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        IAttendanceRepository AttendanceRepository { get; }

        IProgramRepository ProgramRepository { get; }
        Task SaveAsync();
    }
}
