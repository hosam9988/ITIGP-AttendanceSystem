using Contracts;
using Contracts.ServicesContracts;
using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attendence_GP.Controllers
{
    [Route("trackAction/{trackActionId}/[controller]/")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentServices _studentServices;
        
        public StudentsController(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }

        [HttpPost]
        public async Task AddStudent(int trackActionId, [FromBody] Student student)
        {
            await _studentServices.Create(trackActionId, student);
        }

        #region Read
        [HttpGet]
        public async Task<IActionResult> GetStudentsForTrack(int trackActionId)
        {
            var students = await _studentServices.GetStudentsForTrack(trackActionId);
            return Ok(students);
        }
        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetStudentPerId(int trackActionId, int studentId)
        {
            
            var student = await _studentServices.GetStudent(trackActionId, studentId);
            return Ok(student);
        }
        #endregion

        [HttpPut("{studentId}")]
        
        public async Task<IActionResult> UpdateStudentForTrack(int trackActionId, int studentId, [FromBody] UpdateStudentVM student)
        {
            await _studentServices.Update(trackActionId, studentId, student);
            return NoContent();
        }


        [HttpDelete("{studentId}")]

        public async Task<IActionResult> DeleteStudentForTrack(int trackActionId, int studentId)
        {
            await _studentServices.Delete(trackActionId, studentId);
            return NoContent();
        }
    }
}
