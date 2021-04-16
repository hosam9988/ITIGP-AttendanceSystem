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
    [Route("tracks/{trackActionId}/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IServicesManager _manager;
        public AttendanceController(IServicesManager manager)
        {
            _manager = manager;
        }

        #region Create 
        [HttpPost("{studentId}")]
        public async Task AddStudentToAttendance(int trackActionId,int studentId ,[FromBody] AttendanceManipulationDto attendance)
        {
            await _manager.AttendanceServices.Create(studentId, attendance);
        }
        #endregion

        #region Read
        [HttpGet]
        public async Task<IActionResult> GetStudentsForTrack(int trackActionId, DateTime date)
        {
            var students = await _manager.AttendanceServices.GetAttendanceForTrack(trackActionId, date);
            return Ok(students);
        }
        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetAttendanceForStudent(int studentId)
        {
            var student = await _manager.AttendanceServices.GetAttendanceForStudent(studentId, DateTime.Now.Date);
            return Ok(student);
        }
        #endregion

        #region update
        [HttpPut("{studentId}")]

        public async Task<IActionResult> UpdateAttendanceForStudent(int studentId,[FromBody] AttendanceManipulationDto attendance)
        {
            await _manager.AttendanceServices.Update(studentId, DateTime.Now, attendance);
            return NoContent();
        }
        #endregion

        #region Delete
        [HttpDelete("{studentId}")]

        public async Task<IActionResult> DeleteAttendance(int studentId, DateTime date)
        {
            await _manager.AttendanceServices.Delete(studentId, date);
            return NoContent();
        }
        #endregion

    }
}
