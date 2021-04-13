using System.Threading.Tasks;

namespace Contracts
{
    //Unit Of Work DP 
    public interface IAppRepositoryManager
    {
        IStudentRepository StudentRepository { get; }
        ITrackActionRepository TrackActionRepository { get; }
        ITrackRepository TrackRepository { get; }
        Task SaveAsync();
    }
}
