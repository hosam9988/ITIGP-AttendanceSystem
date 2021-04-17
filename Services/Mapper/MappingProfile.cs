using AutoMapper;
using Domain.Dtos;
using Domain.Models;
using System;

namespace Services.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Student Mapper
            CreateMap<Student, StudentReadDto>().ReverseMap();
            CreateMap<Student, StudentAttendanceReadDto>().ReverseMap();
            CreateMap<StudentManipulationDto, Student>().ReverseMap();
            #endregion

            #region Track Mapper
            CreateMap<TrackManipulationDto, Track>().ReverseMap();
            CreateMap<Track, TrackReadDto>().ForMember(t => t.ProgramName, opt => opt.MapFrom(x => x.Program.Name));
            #endregion

            #region TRackAction Mapper
            CreateMap<TrackAction, TrackActionReadDto>().ReverseMap();
            CreateMap<TrackActionManipulationDto, TrackAction>().ReverseMap();
            #endregion

            #region Permissions Mapper 
            CreateMap<Permission, PermissionStudentReadDto>().ForMember(x => x.Type, opt => opt.MapFrom(src => src.Type ? "Apsent" : "Late"))
                .ForMember(x => x.ResponseType, opt => opt.MapFrom(src => (bool)src.ResponseType ? "Accepted" : "Refused"));
            CreateMap<PermissionStudentManipulationDto, Permission>().ReverseMap();

            CreateMap<Permission, PermissionEmployeeReadDto>().ForMember(x => x.StudentName, opt => opt.MapFrom(x => x.Student.Name))
                .ForMember(x => x.TrackName, opt => opt.MapFrom(x => x.Student.TrackAction.Track.Name))
                .ForMember(x => x.Type, opt => opt.MapFrom(src => src.Type ? "Apsent" : "Late"));
            CreateMap<PermissionEmployeeManipulationDto, Permission>().ReverseMap();
            #endregion

            #region Employee Mapper
            CreateMap<Employee, EmployeeReadDto>().ReverseMap();
            CreateMap<EmployeeManipulationDto, Employee>().ReverseMap();
            #endregion

            #region Attendance Mapper 
            CreateMap<Attendance, AttendanceManipulationDto>().ForMember(t => t.AttendAt, opt => opt.MapFrom(x => 
                x.AttendAt.Value.ToString()
               ));

            

            CreateMap<AttendanceManipulationDto, Attendance>().
                ForMember(att => att.AttendAt, opt => opt.MapFrom(x => TimeSpan.Parse(x.AttendAt)));
                
            #endregion
        }
    }
}
