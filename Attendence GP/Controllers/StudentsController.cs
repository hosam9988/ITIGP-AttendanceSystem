using Contracts.ServicesContracts;
using Domain.Dtos;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Attendence_GP.Controllers
{
    [Route("trackAction/")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IServicesManager _manager;

        public StudentsController(IServicesManager manager)
        {
            _manager = manager;
        }
        #region Create 
        //[HttpPost("{trackActionId}/[controller]/")]
        //public async Task AddStudent(int trackActionId, [FromBody] StudentManipulationDto student)
        //{
        //    await _manager.StudentServices.Create(trackActionId, student);
        //}
        #endregion

        #region Read
        [HttpGet("{trackActionId}/[controller]/")]
        public async Task<IActionResult> GetStudentsForTrack(int trackActionId)
        {
            var students = await _manager.StudentServices.GetStudentsForTrack(trackActionId);
            
            if(students != null)
            return Ok(students);
            else
                return NotFound();
        }
        [HttpGet("/[controller]/{studentId}")]
        public async Task<IActionResult> GetStudentPerId(int studentId)
        {

            var student = await _manager.StudentServices.GetStudent(studentId);
            return Ok(student);
        }
        #endregion

        #region update
        [HttpPut("/[controller]/{studentId}")]

        public async Task<IActionResult> UpdateStudentForTrack(int studentId, [FromBody] StudentManipulationDto student)
        {
            await _manager.StudentServices.Update(studentId, student);
            return NoContent();
        }
        #endregion

        #region Delete
        [HttpDelete("/[controller]/{studentId}")]

        public async Task<IActionResult> DeleteStudentForTrack(int studentId)
        {
            await _manager.StudentServices.Delete( studentId);
            return NoContent();
        }
        #endregion
    }
}
