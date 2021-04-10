using AutoMapper;
using Contracts;
using Contracts.ServicesContracts;
using Domain.Models;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class StudentServices : IStudentServices
    {
        private readonly IAppRepositoryManager _repositoryManager; //=>use model from student model
        private IMapper _mapper;
        public StudentServices(IAppRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task Create(int trackActionId, Student student)
        {
            _repositoryManager.StudentRepository.CreateStudent(trackActionId, student);
            await _repositoryManager.SaveAsync();
        }



        public Task Delete(int trackActionId, int id)
        {
            throw new NotImplementedException();
        }


        public async Task<List<StudentViewModel>> GetStudentsForTrack(int trackActionId, bool trackChanges)
        {
            var students = await _repositoryManager.StudentRepository.GetStudents(trackActionId, trackChanges: false);
            var studentsViewModel = _mapper.Map<IEnumerable<StudentViewModel>>(students);
            return studentsViewModel.ToList();
        }

        public async Task Update(int trackActionId, int id, Student student)
        {
            _repositoryManager.StudentRepository.UpdateStudent(student);
            await _repositoryManager.SaveAsync();

        }

        
        public async Task<StudentViewModel> GetStudent(int trackActionId, int id, bool trackChanges)
        {
            var student = await _repositoryManager.StudentRepository.GetStudentAsync(trackActionId, id, trackChanges: false);
            var studentsViewModel = _mapper.Map<StudentViewModel>(student);
            return studentsViewModel;
        }
        


    }
}

