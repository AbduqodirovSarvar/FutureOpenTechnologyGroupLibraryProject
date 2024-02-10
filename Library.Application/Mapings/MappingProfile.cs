using AutoMapper;
using Library.Application.Models.ViewModels;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Mapings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<User, UserViewModel>()
                .ForMember(x => x.RoleName, y => y.MapFrom(z => z.Role.ToString()));
        }
    }
}
