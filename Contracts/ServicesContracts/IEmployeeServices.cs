using Domain.Dtos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ServicesContracts
{
    public interface IEmployeeServices
    {
        Task Create(EmployeeManipulationDto employee);
        Task Update( int employeeId, EmployeeManipulationDto employee);
        Task Delete(int employeeId);
        Task<EmployeeReadDto> GetEmployee(int employeeId);
        Task<List<EmployeeReadDto>> GetEmployees();
    }
}
