using Contracts.ServicesContracts;
using Domain.Dtos;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Attendence_GP.Controllers
{
    [Route("trackAction/{trackActionId}/[controller]/")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IServicesManager _manager;

        public StudentsController(IServicesManager manager)
        {
            _manager = manager;
        }
        #region Create 
        [HttpPost]
        public async Task AddStudent(int trackActionId, [FromBody] StudentManipulationDto student)
        {
            await _manager.StudentServices.Create(trackActionId, student);
        }
        #endregion

        #region Read
        [HttpGet]
        public async Task<IActionResult> GetStudentsForTrack(int trackActionId)
        {
            var students = await _manager.StudentServices.GetStudentsForTrack(trackActionId);
            return Ok(students);
        }
        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetStudentPerId(int studentId)
        {

            var student = await _manager.StudentServices.GetStudent(studentId);
            return Ok(student);
        }
        #endregion

        #region update
        [HttpPut("{studentId}")]

        public async Task<IActionResult> UpdateStudentForTrack(int trackActionId, int studentId, [FromBody] StudentManipulationDto student)
        {
            await _manager.StudentServices.Update(studentId, student);
            return NoContent();
        }
        #endregion

        #region Delete
        [HttpDelete("{studentId}")]

        public async Task<IActionResult> DeleteStudentForTrack(int trackActionId, int studentId)
        {
            await _manager.StudentServices.Delete( studentId);
            return NoContent();
        }
        #endregion
    }
}
