using Contracts.ServicesContracts;
using Domain.Dtos;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Attendence_GP.Controllers
{
    [Route("students/{studentId}/[controller]/")]
    [ApiController]
    public class PermissionsStudentController :ControllerBase
    {
        private readonly IServicesManager _manager;

        public PermissionsStudentController(IServicesManager manager)
        {
            _manager = manager;
        }

        #region Create 
        [HttpPost]
        public async Task AddPermission(int studentId, [FromBody] PermissionStudentManipulationDto permission)
        {
            await _manager.PermissionServices.Create(studentId, permission);
        }
        #endregion

        #region Read
        [HttpGet]
        public async Task<IActionResult> GetPermissionsForStudent(int studentId)
        {
            var permissions = await _manager.PermissionServices.GetPermissionsForStudent(studentId);
            return Ok(permissions);
        }
        [HttpGet("{permissionId}")]
        public async Task<IActionResult> GetPermissionPerId(int studentId, int permissionId)
        {

            var permission = await _manager.PermissionServices.GetPermission(studentId, permissionId);
            return Ok(permission);
        }
        #endregion

        #region update
        [HttpPut("{permissionId}")]

        public async Task<IActionResult> UpdatePermissionForStudent(int studentId, int permissionId, [FromBody] PermissionStudentManipulationDto permission)
        {
            await _manager.PermissionServices.Update(studentId, permissionId, permission);
            return NoContent();
        }
        #endregion

        #region Delete
        [HttpDelete("{permissionId}")]

        public async Task<IActionResult> DeleteStudentForTrack(int studentId, int permissionId)
        {
            await _manager.PermissionServices.Delete(studentId, permissionId);
            return NoContent();
        }
        #endregion



    }
}
