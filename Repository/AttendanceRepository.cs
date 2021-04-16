using Contracts.RepositoryContracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AttendanceRepository : AppRepository<Attendance>,IAttendanceRepository
    {
        public AttendanceRepository(ITIAttendanceContext context) : base(context)
        {
        }

        public void CreateTrackAttendance(int studentId,Attendance attendance)
        {
            var student = _context.Students.SingleOrDefault(s=>s.Id ==studentId);
            attendance.Student = student;
            Create(attendance);
        }

        public void DeleteAttendance(Attendance attendance)=> Delete(attendance);
       
        /// <summary>
        /// get the attendance for certain student to make any operation on. 
        /// </summary>
        /// <param name="trackActionId"></param>
        /// <param name="date"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>

        public async Task<Attendance> GetAttendanceForStudent(int studentId, DateTime date, bool trackChanges) =>
            await FindByCondition(att => att.StudentId == studentId && att.Date.Equals(date), trackChanges).SingleOrDefaultAsync();

        //needs some Work on logic
        public async Task<Attendance> GetAttendanceForTrack(int trackActionId, DateTime date, bool trackChanges)=>
        await FindByCondition(att =>att.Student.TrackActionId == trackActionId && att.Date.Equals(date), trackChanges).SingleOrDefaultAsync();


        /// <summary>
        /// to return all students in the track to take attendnce for.
        /// </summary>
        /// <param name="trackActionId"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        public async Task<List<Student>>  GetStudentsForAttendance(int trackActionId) =>
            await _context.Students.Where(x => x.TrackActionId == trackActionId).AsNoTracking().ToListAsync(); 

    }
}
