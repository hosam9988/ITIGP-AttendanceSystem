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
    [Route("track/{trackActionId}/[controller]/")]
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

        [HttpGet]
        public async Task<IActionResult> GetStudentsForTrack(int trackActionId, bool trackChanges)
        {
            var students = await _studentServices.GetStudentsForTrack(trackActionId, trackChanges: false);
            return Ok(students);
        }
        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetStudentPerId(int trackActionId, int studentId, bool trackChanges)
        {
            
            var student = await _studentServices.GetStudent(trackActionId, studentId, false);
            return Ok(student);
        }

        [HttpPut("{studentId}")]
        
        public async Task<IActionResult> UpdateStudentForTrack(int trackActionId, int studentId, [FromBody] UpdateStudentVM student)
        {
            await _studentServices.Update(trackActionId, studentId, student);
            return NoContent();
        }
    }
}
