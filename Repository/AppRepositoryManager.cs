using Contracts;
using Contracts.RepositoryContracts;
using Domain.Models;
using System;
using System.Threading.Tasks;

namespace Repository
{
    public class AppRepositoryManager : IAppRepositoryManager
    {
        private readonly ITIAttendanceContext _context;
        private IStudentRepository _studentRepository;
        private ITrackActionRepository _trackActionRepository;
        private ITrackRepository _trackRepository;
        private IPermissionRepository _permissionRepository;
        private IEmployeeRepository _employeeRepository;

        public AppRepositoryManager(ITIAttendanceContext context)
        {
            _context = context;
        }

        public ITrackActionRepository TrackActionRepository
        {
            get
            {
                if (_trackActionRepository == null) _trackActionRepository = new TrackActionRepository(_context);
                return _trackActionRepository;
            }
        }

        public IStudentRepository StudentRepository
        {
            get
            {
                if (_studentRepository == null) _studentRepository = new StudentRepository(_context);
                return _studentRepository;
            }
        }

        public ITrackRepository TrackRepository
        {
            get
            {
                if (_trackRepository == null) _trackRepository = new TrackRepository(_context);
                return _trackRepository;
            }
        }
        public IPermissionRepository PermissionRepository
        {
            get
            {
                if (_permissionRepository == null) _permissionRepository = new PermissionRepository(_context);
                return _permissionRepository;
            }
        }

        public IEmployeeRepository EmployeeRepository
        {
            get
            {
                if (_employeeRepository == null) _employeeRepository = new EmployeeRepository(_context);
                return _employeeRepository;
            }
        }

        public async Task SaveAsync() => await _context.SaveChangesAsync();

    }
}
