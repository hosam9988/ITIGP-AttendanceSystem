using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attendence_GP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentServices _studentServices;
        public StudentsController(StudentServices studentServices)
        {
            _studentServices = studentServices;
        }

        [HttpPost]
        public void AddStudent(Student student)
        {
            _studentServices.create(student);
        }
    }
}
