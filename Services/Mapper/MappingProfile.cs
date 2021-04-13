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
            CreateMap<TrackAction, TrackActionReadDto>().ReverseMap();
        }
    }
}
