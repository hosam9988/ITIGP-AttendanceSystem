using Contracts.RepositoryContracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    class EmployeeRepository : AppRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ITIAttendanceContext context) : base(context)
        {
        }
        public void CreateEmployee(Employee employee)
        {
            Create(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            Delete(employee);
        }

        public async Task<Employee> GetEmployeeAsync(int employeeId, bool trackChanges) =>
            await FindByCondition(e => e.Id == employeeId, trackChanges).SingleOrDefaultAsync();

        public async Task<List<Employee>> GetEmployees( bool trackChanges) =>
             await FindAll( trackChanges).ToListAsync();
    }
}
