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
            CreateMap<Student, StudentReadDto>().ForMember(x => x.CreatedBy, opt => opt.MapFrom(src => src.CreatedByNavigation.Name));
            CreateMap<Student, StudentAttendanceReadDto>().ReverseMap();
            CreateMap<StudentManipulationDto, Student>().ReverseMap();
            #endregion

            #region Track Mapper
            CreateMap<TrackManipulationDto, Track>().ReverseMap();
            CreateMap<Track, TrackReadDto>().ForMember(t => t.ProgramName, opt => opt.MapFrom(x => x.Program.Name));
            #endregion

            #region TRackAction Mapper
            CreateMap<TrackAction, TrackActionReadDto>().ForMember(x => x.TrackName, opt => opt.MapFrom(src => src.Track.Name));
            CreateMap<TrackActionManipulationDto, TrackAction>().ReverseMap();
            #endregion

            #region Permissions Mapper 
            CreateMap<Permission, PermissionStudentReadDto>().ForMember(x => x.Type, opt => opt.MapFrom(src => src.Type ? "Apsent" : "Late"))
                .ForMember(x => x.ResponseType, opt => opt.MapFrom(src => src.ResponseType ? "Accepted" : "Refused"));
            CreateMap<PermissionStudentManipulationDto, Permission>().ReverseMap();

            CreateMap<Permission, PermissionEmployeeReadDto>().ForMember(x => x.StudentName, opt => opt.MapFrom(x => x.Student.Name))
                .ForMember(x => x.TrackName, opt => opt.MapFrom(x => x.Student.TrackAction.Track.Name))
                .ForMember(x => x.Type, opt => opt.MapFrom(src => src.Type ? "Apsent" : "Late"));
            CreateMap<PermissionEmployeeManipulationDto, Permission>().ReverseMap();
            #endregion

            #region Employee Mapper
            CreateMap<Employee, EmployeeReadDto>().ForMember(x => x.RoleName, opt => opt.MapFrom(src => src.Role.Role1))
                .ForMember(x => x.CreatedBy, opt => opt.MapFrom(src => src.CreatedByNavigation.Name));
            CreateMap<EmployeeManipulationDto, Employee>().ReverseMap();
            #endregion

            #region Attendance Mapper 
            //read
            CreateMap<Attendance, StudentAttendanceReadDto>().ForMember(t => t.AttendAt, opt => opt.MapFrom(x =>
                x.AttendAt.Value.ToString()
               )).ForMember(t => t.LeaveAt, opt => opt.MapFrom(x =>
                x.LeaveAt.Value.ToString()))
               .ForMember(x => x.StudentName, opt => opt.MapFrom(src => src.Student.Name));

            
            //create
            CreateMap<AttendanceManipulationDto, Attendance>().
                ForMember(att => att.AttendAt, opt => opt.MapFrom(x => TimeSpan.Parse(x.AttendAt)))  
                .ForMember(att => att.LeaveAt, opt => opt.MapFrom(x => TimeSpan.Parse(x.LeaveAt)));

            #endregion

            #region Program Mapper
            CreateMap<Program, ProgramManipulationDto>().ReverseMap();
            CreateMap<Program, ProgramReadDto>().ReverseMap();
            #endregion
        }
    }
}
