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
        public void CreateEmployee(int userId, Employee employee)
        {
            employee.UserId = userId;
            Create(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            Delete(employee);
        }

        public async Task<Employee> GetEmployeeAsync(int employeeId, bool trackChanges) =>
            await FindByCondition(e => e.Id == employeeId, trackChanges)
            .Include(emp => emp.User.Role)
            .Include(emp => emp.User.Employee)
            .Include(x => x.User).Where(x => x.UserId == x.User.Id)
            .SingleOrDefaultAsync();



        public async Task<List<Employee>> GetEmployees(bool trackChanges) =>
            await FindAll(trackChanges).Include(emp => emp.User.Role).Include(emp => emp.CreatedByNavigation).ToListAsync();
    }
}
