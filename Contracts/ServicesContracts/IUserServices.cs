using Domain.Dtos.AuthDtos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ServicesContracts
{
    public interface IUserServices
    {
        Task<LoginReadDto> Login (string userName, string password);
        Task RegisterUser(AppUser user);
    }
}
