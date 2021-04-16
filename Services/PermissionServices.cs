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
        private readonly IAppRepositoryManager _repositoryManager; //=>use model from permission model
        private IMapper _mapper;

        public PermissionServices(IAppRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task Create(int studentId, PermissionStudentManipulationDto permission)
        {
            var permissionsEntity = _mapper.Map<Permission>(permission);
            _repositoryManager.PermissionRepository.CreatePermission(studentId, permissionsEntity);
            await _repositoryManager.SaveAsync();

        }

        public async Task Delete(int studentId, int id)
        {
            var permission = await _repositoryManager.PermissionRepository.GetPermissionAsync(studentId, id, false);
            _repositoryManager.PermissionRepository.DeletePermission(permission);
            await _repositoryManager.SaveAsync();
        }

        public async Task<PermissionStudentReadDto> GetPermission(int studentId, int id)
        {
            var permission = await _repositoryManager.PermissionRepository.GetPermissionAsync(studentId, id, trackChanges: false);
            var permissionsEntity = _mapper.Map<PermissionStudentReadDto>(permission);
            return permissionsEntity;
        }

        public async Task<List<PermissionStudentReadDto>> GetPermissionsForStudent(int studentId)
        {
            var permissions = await _repositoryManager.PermissionRepository.GetPermissionsForStudent(studentId, trackChanges: false);
            var permissionsEntity = _mapper.Map<List<PermissionStudentReadDto>>(permissions);
            return permissionsEntity;
        }

        public async Task<List<PermissionEmployeeReadDto>> GetPermissionsForEmployee()
        {
            var permissions = await _repositoryManager.PermissionRepository.GetAllPermissionsForEmployee(trackChanges: false);
            var permissionsEntity = _mapper.Map<List<PermissionEmployeeReadDto>>(permissions);
            return permissionsEntity;
        }

        public async Task Update(int studentId, int id, PermissionStudentManipulationDto permission)
        {
            var permissionEntity = await _repositoryManager.PermissionRepository.GetPermissionAsync(studentId, id, trackChanges: true);
            _mapper.Map(permission, permissionEntity);
            await _repositoryManager.SaveAsync();
        }

        public async Task UpdateForEmployee(int studentId, int id, PermissionEmployeeManipulationDto permission)
        {
            var permissionEntity = await _repositoryManager.PermissionRepository.GetPermissionAsync(studentId, id, trackChanges: true);
            _mapper.Map(permission, permissionEntity);
            await _repositoryManager.SaveAsync();
        }

    }
}
