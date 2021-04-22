using Contracts.RepositoryContracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository : AppRepository<AppUser>, IUserRepository
    {
        public UserRepository(ITIAttendanceContext context) : base(context)
        {
        }

        public void CreateUser(AppUser user) 
        {
            Create(user);
        }

        public async Task<AppUser> GetUserAsync(string username, string password, bool trackChanges) =>
            await FindByCondition(e => e.Name.Equals(username) && e.Password.Equals(password), trackChanges)
            .Include(src=>  src.Student)
            .Include(src=> src.Employee)
            .Include(src=>src.Role)
            .SingleOrDefaultAsync();

    }
}
