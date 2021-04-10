using AutoMapper;
using Domain.Models;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendence_GP.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StudentViewModel, Student>().ReverseMap();//.ForMember(sVm=>sVm.Name, opt=>opt.MapFrom(st=>st.Name));
        }
    }
}
