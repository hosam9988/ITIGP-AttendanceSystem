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

            CreateMap<Permission, PermissionReadDto>().ReverseMap();
            CreateMap<PermissionManipulationDto, Permission>().ReverseMap();

            CreateMap<Employee, EmployeeReadDto>().ReverseMap();
            CreateMap<EmployeeManipulationDto, Employee>().ReverseMap();
        }
    }
}
