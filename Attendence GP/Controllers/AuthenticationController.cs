using Contracts.ServicesContracts;
using Domain.Dtos;
using Domain.Dtos.AuthDtos;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attendence_GP.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServicesManager _manager;

        public AuthenticationController(IServicesManager manager)
        {
            _manager = manager;
        }

        [Route("register-Employee")]
        [HttpPost]
        public async Task<IActionResult> RegisterEmployee(EmployeeManipulationDto employee)
        {

            var user = new AppUser
            {
                Name = employee.Name,
                Email = employee.Email,
                CreatedDate = employee.CreatedDate,
                RoleId = employee.RoleId,
                Password = employee.Password
            };

            await _manager.UserServices.RegisterUser(user);
            await _manager.EmployeeServices.Create(user.Id, employee);
            return Created("sucessfully created", employee);
        }

        [HttpPost("{trackActionId}/register-student")]
        public async Task<IActionResult> RegisterStudent(int trackActionId, StudentManipulationDto student)
        {
            try
            {
                var user = new AppUser
                {
                    Name = student.Name,
                    Email = student.Email,
                    CreatedDate = student.CreatedDate,
                    RoleId = 4,
                    Password = CreatPassowrd(student.Ssn, student.Name)
                };
                await _manager.UserServices.RegisterUser(user);
                await _manager.StudentServices.Create(trackActionId, user.Id, student);
                return Created("sucessfully created", student);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginCreateDto user)
        {
            var result = await _manager.UserServices.Login(user.UserName, user.Password);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("wrong username or Password");
        }

        string CreatPassowrd(string ssn, string username)
        {
            return username.ToLower().Substring(0, 2) + "ITI" + ssn.Substring(7, 6);
        }
    }



}
