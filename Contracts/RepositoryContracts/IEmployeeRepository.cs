using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RepositoryContracts
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployees(bool trackChanges);
        Task<Employee> GetEmployeeAsync(int employeeId, bool trackChanges);
        void DeleteEmployee(Employee employee);
        //id of logged in Admin to be assigned in the foreign key [ created by ] 
        void CreateEmployee(Employee employee);
    }
}
