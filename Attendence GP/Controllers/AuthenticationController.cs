using Contracts.ServicesContracts;
using Domain.Dtos;
using Domain.Dtos.AuthDtos;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ServiceBus.Messaging;
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
            try
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
                var emp = await _manager.EmployeeServices.Create(user.Id, employee);

                return Created("Employee created successfully", emp);
            }
            catch (BadHttpRequestException)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "User creation failed! Please check user details and try again." });
            }

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
                    Password = GeneratePassword(student.Ssn,student.Name)
                };

                await _manager.UserServices.RegisterUser(user);
                var stud =  await _manager.StudentServices.Create(trackActionId, user.Id, student);

                return Created("Student created successfully", stud);
            }
            catch (BadHttpRequestException)
            {
                return BadRequest();
            }
            catch (InternalServerErrorException)
            {
                return StatusCode(500);
            }
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginCreateDto user)
        {
            try
            {
                var result = await _manager.UserServices.Login(user.UserName, user.Password);
                return Ok(result);
            }
            catch (BadHttpRequestException)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", Message = "User creation failed! Please check user details and try again." });
            }
        }
    
    private string GeneratePassword(string ssn , string name)
        {
            return name.ToLower().Substring(0, 2) + "ITI" + ssn.Substring(7, 6);
        }
    }



}
