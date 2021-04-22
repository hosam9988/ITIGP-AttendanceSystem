using AutoMapper;
using Contracts;
using Contracts.ServicesContracts;
using Domain.Dtos.AuthDtos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserServices : IUserServices
    {
        private readonly IAppRepositoryManager _manager;
        private readonly IMapper _mapper;

        public UserServices(IAppRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }
       
        public async  Task<LoginReadDto> Login(string userName, string password)
        {
            var user = await _manager.UserRepository.GetUserAsync(userName, password, false);
            var loginedUser = _mapper.Map<LoginReadDto>(user);
            return loginedUser;
        }

        public async Task RegisterUser(AppUser user)
        {
            _manager.UserRepository.CreateUser(user);
            await _manager.SaveAsync();
        }
    }
}
