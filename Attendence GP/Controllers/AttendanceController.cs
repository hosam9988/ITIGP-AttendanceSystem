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
        public async Task<IActionResult>  AddStudentToAttendance(int studentId ,[FromBody] AttendanceManipulationDto attendance)
        {
            try
            {
                var att = await _manager.AttendanceServices.Create(studentId, attendance);

                return Created("Attendance created successfully", att);
            }
            catch (BadHttpRequestException)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new{ Status = "Error", Message = "Internal server error" });
            }
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

        public async Task<IActionResult> UpdateAttendanceForStudent(int studentId, [FromBody] AttendanceManipulationDto attendance)
        {

            try
            {
                var date = DateTime.Now.Date.Date;
                await _manager.AttendanceServices.Update(studentId, date, attendance);
                return NoContent();

            }
            catch (BadHttpRequestException)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "Internal server error" });
            }
        }
        #endregion

        #region Delete
        [HttpDelete("[controller]/{studentId}/{date}")]

        public async Task<IActionResult> DeleteAttendance(int studentId, DateTime date)
        {

            try
            {
                await _manager.AttendanceServices.Delete(studentId, date);
                return NoContent();
            }
            catch (BadHttpRequestException)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "Internal server error" });
            }
        }
        #endregion

    }
}
