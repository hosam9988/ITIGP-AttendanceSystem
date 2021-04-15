using AutoMapper;
using Contracts;
using Contracts.ServicesContracts;
using Domain.Dtos;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;
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



        public async Task Delete(int id)
        {
            var student = await _repositoryManager.StudentRepository.GetStudentAsync(id, false);
            _repositoryManager.StudentRepository.DeleteStudent(student);
            await _repositoryManager.SaveAsync();
        }


        public async Task<List<StudentReadDto>> GetStudentsForTrack(int trackActionId)
        {
            var students = await _repositoryManager.StudentRepository.GetStudents(trackActionId, trackChanges: false);
            var studentsViewModel = _mapper.Map<List<StudentReadDto>>(students);
            return studentsViewModel.ToList();
        }

        public async Task Update(int id, StudentUpdateDto student)
        {
            var studentEntity = await _repositoryManager.StudentRepository.GetStudentAsync( id, trackChanges: true);
            _mapper.Map(student, studentEntity);
            await _repositoryManager.SaveAsync();
        }


        public async Task<StudentReadDto> GetStudent( int id)
        {
            var student = await _repositoryManager.StudentRepository.GetStudentAsync( id, trackChanges: false);
            var studentsEntity = _mapper.Map<StudentReadDto>(student);
            return studentsEntity;
        }

        public async Task<List<Student>> GetStudents(int trackActionId)
        {
            var students = await _repositoryManager.StudentRepository.GetStudents(trackActionId, trackChanges: false);
            return students;
        }
    }
}

