using Contracts;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class StudentServices
    {
        private readonly IAppRepository<Student> _appRepository; //=>use model from student model
        public StudentServices(IAppRepository<Student> appRepository)
        {
            _appRepository = appRepository;
        }

        public void create(Student student)
        {
            _appRepository.Create(student);
        }
    }
}
