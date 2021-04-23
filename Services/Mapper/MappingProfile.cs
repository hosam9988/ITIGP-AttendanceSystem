using AutoMapper;
using Domain.Dtos;
using Domain.Dtos.AuthDtos;
using Domain.Models;
using System;

namespace Services.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Student Mapper
            CreateMap<Student, StudentReadDto>()
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(x => x.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(x => x.CreatedBy, opt => opt.MapFrom(src => src.CreatedByNavigation.User.Name));
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
                .ForMember(x => x.ResponseType, opt => opt.MapFrom(src => ResponseTypeStatus(src.ResponseType)));

            CreateMap<PermissionStudentManipulationDto, Permission>().ReverseMap();

            CreateMap<Permission, PermissionEmployeeReadDto>().ForMember(x => x.StudentName, opt => opt.MapFrom(x => x.Student.User.Name))
                .ForMember(x => x.TrackName, opt => opt.MapFrom(x => x.Student.TrackAction.Track.Name))
                .ForMember(x => x.Type, opt => opt.MapFrom(src => src.Type ? "Apsent" : "Late"));
            CreateMap<PermissionEmployeeManipulationDto, Permission>().ReverseMap();
            #endregion

            #region Employee Mapper
            CreateMap<Employee, EmployeeReadDto>()
                .ForMember(x => x.Name, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(x=>x.RoleName, opt=>opt.MapFrom(src=>src.User.Role.RoleName))
                .ForMember(x => x.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(x => x.CreatedBy, opt => opt.MapFrom(src => src.CreatedByNavigation.User.Name));
            CreateMap<EmployeeManipulationDto, Employee>().ReverseMap();
            #endregion

            #region Attendance Mapper 
            //read
            CreateMap<Attendance, StudentAttendanceReadDto>().ForMember(t => t.AttendAt, opt => opt.MapFrom(x =>
                x.AttendAt.Value.ToString()
               )).ForMember(t => t.LeaveAt, opt => opt.MapFrom(x =>
                x.LeaveAt.Value.ToString()))
               .ForMember(t => t.LeaveAt, opt => opt.MapFrom(x =>
                x.LeaveAt == null ? " " : x.LeaveAt.ToString()))
               .ForMember(t => t.AttendAt, opt => opt.MapFrom(x =>
                x.AttendAt == null ? " " : x.AttendAt.ToString()))
               .ForMember(x => x.StudentName, opt => opt.MapFrom(src => src.Student.User.Name));


            //create
            CreateMap<AttendanceManipulationDto, Attendance>().
                ForMember(att => att.AttendAt, opt => opt.MapFrom(x => TimeSpan.Parse(x.AttendAt)))
                .ForMember(att => att.LeaveAt, opt => opt.MapFrom(x => TimeSpan.Parse(x.LeaveAt)));

            #endregion

            #region Program Mapper
            CreateMap<Program, ProgramManipulationDto>().ReverseMap();
            CreateMap<Program, ProgramReadDto>().ReverseMap();
            #endregion


            #region User Mapper
            CreateMap<AppUser, LoginReadDto>().ForMember(x => x.UserName, opt => opt.MapFrom(src => src.Name))
                                              .ForMember(x => x.RoleName, opt => opt.MapFrom(src => src.Role.RoleName))
                                              .ForMember(x => x.UserId, opt => opt.MapFrom(src => src.RoleId == 4 ? src.Student.Id : src.Employee.Id));

            #endregion
        }

        string ResponseTypeStatus(bool? responseType)
        {
            var x = responseType == true ? "Accepted" : "refused";
            if (responseType != null)
                return x;
            return "Pending";
        }



    }
}
