using AutoMapper;
using Contracts;
using Contracts.ServicesContracts;
using Domain.Dtos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Services
{
    public class PermissionServices : IPermissionServices
    {
        private readonly IAppRepositoryManager _repositoryManager; //=>use model from student model
        private IMapper _mapper;
        public PermissionServices(IAppRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task Create(int studentId, Permission permission)
        {
            _repositoryManager.PermissionRepository.CreatePermission(studentId, permission);
            await _repositoryManager.SaveAsync();

        }

        public async Task Delete(int studentId, int id)
        {
            var permission = await _repositoryManager.PermissionRepository.GetPermissionAsync(studentId, id, false);
            _repositoryManager.PermissionRepository.DeletePermission(permission);
            await _repositoryManager.SaveAsync();
        }

        public async Task<PermissionReadDto> GetPermission(int studentId, int id)
        {
            var permission = await _repositoryManager.PermissionRepository.GetPermissionAsync(studentId, id, trackChanges: false);
            var permissionsViewModel = _mapper.Map<PermissionReadDto>(permission);
            return permissionsViewModel;
        }

        public async Task<List<Permission>> GetPermissions(int studentId)
        {
            var permissions = await _repositoryManager.PermissionRepository.GetPermissions(studentId, trackChanges: false);
            return permissions;
        }

        public async Task<List<PermissionReadDto>> GetPermissionsForStudent(int studentId)
        {
            var permissions = await _repositoryManager.PermissionRepository.GetPermissions(studentId, trackChanges: false);
            var permissionsViewModel = _mapper.Map<List<PermissionReadDto>>(permissions);
            return permissionsViewModel;
        }

        public async Task Update(int studentId, int id, PermissionUpdateDto permission)
        {
            var permissionEntity = await _repositoryManager.PermissionRepository.GetPermissionAsync(studentId, id, trackChanges: true);
            _mapper.Map(permission, permissionEntity);
            await _repositoryManager.SaveAsync();
        }
    }
}
