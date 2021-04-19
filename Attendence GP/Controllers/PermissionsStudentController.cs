using Contracts.ServicesContracts;
using Domain.Dtos;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
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
        public async Task AddPermission(int studentId, [FromBody] PermissionStudentManipulationDto permission)
        {
            await _manager.PermissionServices.Create(studentId, permission);
        }
        #endregion

        #region Read
        [HttpGet("{studentId}/[controller]/")]
        public async Task<IActionResult> GetPermissionsForStudent(int studentId)
        {
            var permissions = await _manager.PermissionServices.GetPermissionsForStudent(studentId);
            return Ok(permissions);
        }
        [HttpGet("[controller]/{permissionId}")]
        public async Task<IActionResult> GetPermissionPerId(int permissionId)
        {

            var permission = await _manager.PermissionServices.GetPermission(permissionId);
            return Ok(permission);
        }
        #endregion

        #region update
        [HttpPut("[controller]/{permissionId}")]

        public async Task<IActionResult> UpdatePermissionForStudent(int permissionId, [FromBody] PermissionStudentManipulationDto permission)
        {
            await _manager.PermissionServices.Update(permissionId, permission);
            return NoContent();
        }
        #endregion

        #region Delete
        [HttpDelete("[controller]/{permissionId}")]

        public async Task<IActionResult> DeleteStudentForTrack(int permissionId)
        {
            await _manager.PermissionServices.Delete(permissionId);
            return NoContent();
        }
        #endregion



    }
}
