using Contracts;
using Domain.Models;
using System;
using System.Threading.Tasks;

namespace Repository
{
    public class AppRepositoryManager : IAppRepositoryManager
    {
        private readonly AttendContext _context;
        private IStudentRepository _studentRepository;
        private ITrackActionRepository _trackActionRepository;
        

        public AppRepositoryManager(AttendContext context)
        {
            _context = context;
        }

        public IStudentRepository StudentRepository
        {
            get
            {
                if (_trackActionRepository == null) _trackActionRepository = new TrackActionRepository(_context);
                return _trackActionRepository;
            }
        }

        public ITrackActionRepository TrackActionRepository
        {
            get
            {
                if (_studentRepository == null) _studentRepository = new StudentRepository(_context);
                return _studentRepository;
            }
        }


        public async Task SaveAsync() => await _context.SaveChangesAsync();
        
    }
}
