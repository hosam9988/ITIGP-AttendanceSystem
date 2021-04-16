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
        Task Create(int studentId, PermissionStudentManipulationDto permission);
        Task Update(int studentId, int id, PermissionStudentManipulationDto student);
        Task UpdateForEmployee(int studentId, int id, PermissionEmployeeManipulationDto permission);

        Task Delete(int studentId, int id);
        Task<PermissionStudentReadDto> GetPermission(int studentId, int id);
        Task<List<PermissionStudentReadDto>> GetPermissionsForStudent(int studentId);
        Task<List<PermissionEmployeeReadDto>> GetPermissionsForEmployee();
    }
}
