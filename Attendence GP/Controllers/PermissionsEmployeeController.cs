using Contracts.ServicesContracts;
using Domain.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attendence_GP.Controllers
{
    [Route("[controller]")]
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

            return permissions.Count == 0 ? NotFound() : Ok(permissions);
        }
        #endregion

        #region update
        [HttpPut("{permissionId}")]
        public async Task<IActionResult> UpdatePermissionForStudent(int permissionId, [FromBody] PermissionEmployeeManipulationDto permission)
        {
            try
            {
                await _manager.PermissionServices.UpdateForEmployee(permissionId, permission);
                return NoContent();
            }
            catch (BadHttpRequestException)
            {
                return BadRequest();
            }
            catch (InternalServerErrorException)
            {
                return StatusCode(500);
            }
        }
        #endregion
    }
}
