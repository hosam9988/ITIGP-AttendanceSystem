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
        Task Create(int studentId, PermissionManipulationDto permission); 
        Task Update(int studentId, int id, PermissionManipulationDto student); 
        Task Delete(int studentId, int id); 
        Task<PermissionReadDto> GetPermission(int studentId, int id); 
        Task<List<PermissionReadDto>> GetPermissionsForStudent(int studentId);
        Task<List<PermissionReadDto>> GetPermissions(int studentId);
    }
}
