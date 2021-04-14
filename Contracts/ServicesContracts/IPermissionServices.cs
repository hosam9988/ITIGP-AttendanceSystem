using Domain.Dtos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ServicesContracts
{
    public interface IPermissionServices
    {
        Task Create(int studentId, Permission permission); //
        Task Update(int studentId, int id, PermissionUpdateDto student); //
        Task Delete(int studentId, int id); // 
        Task<PermissionReadDto> GetPermission(int studentId, int id); //
        Task<List<PermissionReadDto>> GetPermissionsForStudent(int studentId);
        Task<List<Permission>> GetPermissions(int studentId);


        //Permission Repository functions
        //void CreatePermission(int studentId, Permission permission);
        //void UpdatePermission(Permission permission);
        //void DeletePermission(Permission permission);
        //Task<Permission> GetPermissionAsync(int studentId, int permissionId, bool trackChanges);
        //Task<List<Permission>> GetPermissions(int studentId, bool trackChanges);
    }
}
