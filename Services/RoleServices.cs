using Contracts;
using Contracts.ServicesContracts;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    class RoleServices : IRoleServices
    {
        private readonly IAppRepositoryManager _repositoryManager;
        public RoleServices(IAppRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task Create(Role role)=>  _repositoryManager.RoleRepository.Create(role);
       
    }
}
