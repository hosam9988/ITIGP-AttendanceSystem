using Domain.Models;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ServicesContracts
{
    public interface IStudentServices
    {
        Task Create(int trackActionId, Student student);
        Task Update(int trackActionId, int id, UpdateStudentVM student);
        Task Delete(int trackActionId, int id);
        Task<StudentViewModel> GetStudent(int trackActionId, int id, bool trackChanges);
        Task<List<StudentViewModel>> GetStudentsForTrack(int trackActionId, bool trackChanges);
    }
}
