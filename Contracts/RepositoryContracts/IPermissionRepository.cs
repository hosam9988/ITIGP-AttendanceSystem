using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RepositoryContracts
{
    public interface IPermissionRepository
    {
        Task<List<Permission>> GetPermissionsForStudent(int studentId, bool trackChanges);
        Task<List<Permission>> GetAllPermissionsForEmployee(bool trackChanges);
        Task<Permission> GetPermissionAsync(int permissionId, bool trackChanges);
        Permission CreatePermission(int studentId, Permission permission);
        void DeletePermission(Permission permission);
    }
}
