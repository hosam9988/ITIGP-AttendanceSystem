using Contracts.RepositoryContracts;
using Domain.Models;
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
        IAppRepository<Role> RoleRepository { get; }
        IProgramRepository ProgramRepository { get; }
        IUserRepository UserRepository { get; }
        Task SaveAsync();
    }
}
