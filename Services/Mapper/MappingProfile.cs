using AutoMapper;
using Domain.Dtos;
using Domain.Models;

namespace Services.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentReadDto>().ReverseMap();
            CreateMap<StudentManipulationDto, Student>().ReverseMap();

            CreateMap<TrackManipulationDto, Track>().ReverseMap();
            CreateMap<Track, TrackReadDto>().ForMember(t => t.ProgramName, opt => opt.MapFrom(x => x.Program.Name));

            CreateMap<TrackAction, TrackActionReadDto>().ReverseMap();
            CreateMap<TrackActionManipulationDto, TrackAction>().ReverseMap();

            CreateMap<Permission, PermissionStudentReadDto>().ForMember(x => x.Type, opt => opt.MapFrom(src => src.Type ? "Apsent" : "Late"))
                .ForMember(x => x.ResponseType, opt => opt.MapFrom(src => src.Type ? "Accepted" : "Refused"));
            CreateMap<PermissionStudentManipulationDto, Permission>().ReverseMap();

            CreateMap<Permission, PermissionEmployeeReadDto>().ForMember(x => x.StudentName, opt => opt.MapFrom(x => x.Student.Name))
                .ForMember(x => x.TrackName, opt => opt.MapFrom(x => x.Student.TtackAction.Track.Name))
                .ForMember(x => x.Type, opt => opt.MapFrom(src => src.Type ? "Apsent" : "Late"));
            CreateMap<PermissionEmployeeManipulationDto, Permission>().ReverseMap();

            CreateMap<Employee, EmployeeReadDto>().ReverseMap();
            CreateMap<EmployeeManipulationDto, Employee>().ReverseMap();

        }
    }
}
