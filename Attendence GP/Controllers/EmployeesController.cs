using Contracts.ServicesContracts;
using Domain.Dtos;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attendence_GP.Controllers
{
    [Route("[controller]/")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IServicesManager _manager;

        public EmployeesController(IServicesManager manager)
        {
            _manager = manager;
        }

        #region Create 
        [HttpPost]
        public async Task AddEmployee(EmployeeManipulationDto employee)
        {
            await _manager.EmployeeServices.Create(employee);
        }
        #endregion

        #region Read
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _manager.EmployeeServices.GetEmployees();
            return Ok(employees);
        }
        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetEmployee(int employeeId)
        {

            var employee = await _manager.EmployeeServices.GetEmployee(employeeId);
            return Ok(employee);
        }
        #endregion

        #region update
        [HttpPut("{employeeId}")]

        public async Task<IActionResult> UpdateEmployee(int employeeId, [FromBody] EmployeeManipulationDto employee)
        {
            await _manager.EmployeeServices.Update(employeeId, employee);
            return NoContent();
        }
        #endregion

        #region Delete
        [HttpDelete("{employeeId}")]

        public async Task<IActionResult> DeleteEmployee(int employeeId)
        {
            await _manager.EmployeeServices.Delete(employeeId);
            return NoContent();
        }
        #endregion
    }
}
