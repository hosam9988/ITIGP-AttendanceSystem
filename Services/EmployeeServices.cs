using AutoMapper;
using Contracts;
using Contracts.ServicesContracts;
using Domain.Dtos;
using Domain.Dtos.AuthDtos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class EmployeeServices :IEmployeeServices
    {
        private readonly IAppRepositoryManager _repositoryManager; 
        private readonly IMapper _mapper;

        public EmployeeServices(IAppRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<EmployeeReadDto> Create(int userId, EmployeeManipulationDto employee)
        {
            var employeeEntity = _mapper.Map<Employee>(employee);
           var emp = _repositoryManager.EmployeeRepository.CreateEmployee(userId, employeeEntity);
            await _repositoryManager.SaveAsync();

            return _mapper.Map<EmployeeReadDto>(emp);
        }

        public async Task Delete(int employeeId)
        {
            var employee = await _repositoryManager.EmployeeRepository.GetEmployeeAsync(employeeId, false);
            _repositoryManager.EmployeeRepository.DeleteEmployee(employee);
            await _repositoryManager.SaveAsync();
        }

        public async Task<EmployeeReadDto> GetEmployee(int employeeId)
        {
            var employee = await _repositoryManager.EmployeeRepository.GetEmployeeAsync(employeeId, trackChanges: false);
            var employeeEntity = _mapper.Map<EmployeeReadDto>(employee);
            return employeeEntity;
        }

        public async Task<List<EmployeeReadDto>> GetEmployees()
        {
            var employees = await _repositoryManager.EmployeeRepository.GetEmployees(trackChanges: false);
            return _mapper.Map<List<EmployeeReadDto>>(employees);
        }

        public Task<LoginReadDto> Login()
        {
            throw new NotImplementedException();
        }

        public async Task Update(int employeeId, EmployeeManipulationDto employee)
        {
            var employeeEntity = await _repositoryManager.EmployeeRepository.GetEmployeeAsync(employeeId, trackChanges: true);
            _mapper.Map(employee, employeeEntity);
            await _repositoryManager.SaveAsync();
        }
    }
}
