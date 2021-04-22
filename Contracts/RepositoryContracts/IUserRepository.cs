using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RepositoryContracts
{
    public interface IUserRepository
    {
        //Task<List<AppUser>> GetStudents(int trackActionId, bool trackChanges);
        Task<AppUser> GetUserAsync(string username, string password, bool trackChanges);
        void CreateUser(AppUser user);

    }
}
