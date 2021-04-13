using Contracts;
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

        public async Task SaveAsync() => await _context.SaveChangesAsync();

    }
}
