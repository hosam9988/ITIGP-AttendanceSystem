using AutoMapper;
using Contracts;
using Contracts.ServicesContracts;
using Domain.Dtos;
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
        private readonly IAppRepositoryManager _repositoryManager; //=>use model from employee model
        private IMapper _mapper;

        public EmployeeServices(IAppRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task Create(int employeeId, EmployeeManipulationDto employee)
        {
            var EmployeeViewModel = _mapper.Map<Employee>(employee);
            _repositoryManager.EmployeeRepository.CreateEmployee(employeeId, EmployeeViewModel);
            await _repositoryManager.SaveAsync();
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
            var employeeViewModel = _mapper.Map<EmployeeReadDto>(employee);
            return employeeViewModel;
        }

        public async Task<List<EmployeeReadDto>> GetEmployees()
        {
            var employees = await _repositoryManager.EmployeeRepository.GetEmployees(trackChanges: false);
            return _mapper.Map<List<EmployeeReadDto>>(employees);
        }

        public async Task Update(int employeeId, EmployeeManipulationDto employee)
        {
            var employeeEntity = await _repositoryManager.EmployeeRepository.GetEmployeeAsync(employeeId, trackChanges: true);
            _mapper.Map(employee, employeeEntity);
            await _repositoryManager.SaveAsync();
        }
    }
}
