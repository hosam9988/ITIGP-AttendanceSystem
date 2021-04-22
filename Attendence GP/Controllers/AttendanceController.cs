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
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IServicesManager _manager;
        public AttendanceController(IServicesManager manager)
        {
            _manager = manager;
        }

        #region Create 
        
        [HttpPost("[controller]/{studentId}")]
        public async Task AddStudentToAttendance(int studentId ,[FromBody] AttendanceManipulationDto attendance)
        {
            await _manager.AttendanceServices.Create(studentId, attendance);
        }
        #endregion

        #region Read
        [HttpGet("tracks/{trackActionId}/[controller]/{date}")]
        public async Task<IActionResult> GetAttendanceForTrack(int trackActionId, DateTime date)
        {
            var students = await _manager.AttendanceServices.GetAttendanceForTrack(trackActionId, date);
            return students.Count == 0 ? NotFound() : Ok(students);
            
        }
        [HttpGet("[controller]/{studentId}")]
        public async Task<IActionResult> GetAttendanceForStudent(int studentId)
        {
            var date = DateTime.Now.Date.Date;
            var student = await _manager.AttendanceServices.GetAttendanceForStudent(studentId, DateTime.Now.Date);
            return student== null ? NotFound() : Ok(student);
        }
        #endregion

        #region update
        [HttpPut("[controller]/{studentId}")]

        public async Task<IActionResult> UpdateAttendanceForStudent(int studentId,[FromBody] AttendanceManipulationDto attendance)
        {
            var date = DateTime.Now.Date.Date;
            await _manager.AttendanceServices.Update(studentId, date, attendance);
            return NoContent();
        }
        #endregion

        #region Delete
        [HttpDelete("[controller]/{studentId}/{date}")]

        public async Task<IActionResult> DeleteAttendance(int studentId, DateTime date)
        {
            await _manager.AttendanceServices.Delete(studentId, date);
            return NoContent();
        }
        #endregion

    }
}
