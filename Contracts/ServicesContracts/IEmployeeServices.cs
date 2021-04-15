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
        Task Create(int employeeId, EmployeeManipulationDto employee);
        Task Update( int employeeId, EmployeeManipulationDto employee);
        Task Delete(int employeeId);
        Task<EmployeeReadDto> GetEmployee(int employeeId);
        Task<List<EmployeeReadDto>> GetEmployees();



        //Employee Repository functions

        //void CreateEmployee(int employeeId, Employee employee);
        //void UpdateEmployee(Employee employee);
        //void DeleteEmployee(Employee employee);
        //Task<Employee> GetEmployeeAsync(int employeeId, bool trackChanges);
        //Task<List<Employee>> GetEmployees(bool trackChanges);
    }
}
