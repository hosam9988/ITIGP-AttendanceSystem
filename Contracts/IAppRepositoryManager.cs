using Domain.Models;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IAppRepositoryManager
    {
        IStudentRepository StudentRepository { get; }
        ITrackActionRepository TrackActionRepository { get; }
       
        Task SaveAsync();
    }
}
