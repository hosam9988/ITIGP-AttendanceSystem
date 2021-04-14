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
            CreateMap<StudentUpdateDto, Student>().ReverseMap();
            CreateMap<TrackUpdateDto, Track>().ReverseMap();
            CreateMap<Track, TrackReadDto>().ForMember(t => t.ProgramName, opt => opt.MapFrom(x => x.Program.Name));
            CreateMap<TrackAction, TrackActionReadDto>().ReverseMap();
            CreateMap<Permission, PermissionReadDto>().ReverseMap();
            CreateMap<PermissionUpdateDto, Permission>().ReverseMap();
        }
    }
}
