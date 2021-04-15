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
        Task<List<Permission>> GetPermissions(int studentId, bool trackChanges);
        Task<Permission> GetPermissionAsync(int studentId, int permissionId, bool trackChanges);
        void CreatePermission(int studentId, Permission permission);
        void DeletePermission(Permission permission);
    }
}
