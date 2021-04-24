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
        private readonly IMapper _mapper;
        public StudentServices(IAppRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<StudentReadDto> Create(int trackActionId, int userId, StudentManipulationDto student)
        {
            var studentsEntity = _mapper.Map<Student>(student);
           var stud= _repositoryManager.StudentRepository.CreateStudent(trackActionId, userId, studentsEntity);
            await _repositoryManager.SaveAsync();
            var entity =  _mapper.Map<StudentReadDto>(stud);
            return entity;
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
            var studentsEntity = _mapper.Map<List<StudentReadDto>>(students);
            return studentsEntity.ToList();
        }

        public async Task Update(int id, StudentManipulationDto student)
        {
            var studentEntity = await _repositoryManager.StudentRepository.GetStudentAsync( id, trackChanges: true);
            _mapper.Map(student, studentEntity);
            await _repositoryManager.SaveAsync();
        }


        public async Task<StudentReadDto> GetStudent(int id)
        {
            var student = await _repositoryManager.StudentRepository.GetStudentAsync( id, trackChanges: false);
            var studentsEntity = _mapper.Map<StudentReadDto>(student);
            return studentsEntity;
        }

        
    }
}

