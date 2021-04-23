using Contracts.ServicesContracts;
using Domain.Dtos;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ServiceBus.Messaging;
using System.Threading.Tasks;

namespace Attendence_GP.Controllers
{
    [Route("students/")]
    [ApiController]
    public class PermissionsStudentController :ControllerBase
    {
        private readonly IServicesManager _manager;

        public PermissionsStudentController(IServicesManager manager)
        {
            _manager = manager;
        }

        #region Create 
        [HttpPost("{studentId}/[controller]/")]
        public async Task<ActionResult> AddPermission(int studentId, [FromBody] PermissionStudentManipulationDto permission)
        {
            try
            {
               var per = await _manager.PermissionServices.Create(studentId, permission);
                return Created("permission created successfully", per);
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

        #region Read
        [HttpGet("{studentId}/[controller]/")]
        public async Task<IActionResult> GetPermissionsForStudent(int studentId)
        {
            var permissions = await _manager.PermissionServices.GetPermissionsForStudent(studentId);
            return permissions.Count == 0 ? NotFound() : Ok(permissions);
        }
        [HttpGet("[controller]/{permissionId}")]
        public async Task<IActionResult> GetPermissionPerId(int permissionId)
        {
            var permission = await _manager.PermissionServices.GetPermission(permissionId);
            return permission == null ? NotFound() : Ok(permission);
        }
        #endregion

        #region update
        [HttpPut("[controller]/{permissionId}")]

        public async Task<IActionResult> UpdatePermissionForStudent(int permissionId, [FromBody] PermissionStudentManipulationDto permission)
        {
            try
            {
                await _manager.PermissionServices.Update(permissionId, permission);
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

        #region Delete
        [HttpDelete("[controller]/{permissionId}")]

        public async Task<IActionResult> DeleteStudentForTrack(int permissionId)
        {
            try
            {
                await _manager.PermissionServices.Delete(permissionId);
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
