using Contracts.ServicesContracts;
using Domain.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attendence_GP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsEmployeeController : ControllerBase
    {
        private readonly IServicesManager _manager;

        public PermissionsEmployeeController(IServicesManager manager)
        {
            _manager = manager;
        }

        #region Read
        [HttpGet]
        public async Task<IActionResult> GetAllPermissions()
        {
            var permissions = await _manager.PermissionServices.GetPermissionsForEmployee();
            return Ok(permissions);
        }
        #endregion

        #region update
        [HttpPut]
        public async Task<IActionResult> UpdatePermissionForStudent(int studentId, int permissionId, [FromBody] PermissionEmployeeManipulationDto permission)
        {
            await _manager.PermissionServices.UpdateForEmployee(studentId, permissionId, permission);
            return NoContent();
        }
        #endregion
    }
}
