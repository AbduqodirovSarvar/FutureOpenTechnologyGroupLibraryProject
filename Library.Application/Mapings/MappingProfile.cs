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
            CreateMap<Address, AddressViewModel>()
                .ForMember(x => x.RegionName, y => y.MapFrom(z => z.Region != null ? z.Region.Name : null))
                .ForMember(x => x.Cityid, y => y.MapFrom(z => z.Region != null ? z.Region.CityId : (Guid?)null))
                .ForMember(x => x.CityName, y => y.MapFrom(z => (z.Region != null && z.Region.City != null) ? z.Region.City.Name : null))
                .ForMember(x => x.CountryId, y => y.MapFrom(z => (z.Region != null && z.Region.City != null) ? z.Region.City.CountryId : (Guid?)null))
                .ForMember(x => x.CountryName, y => y.MapFrom(z => z.Region != null ? z.Region.City : null))
                .ReverseMap();
            CreateMap<Book, BookViewModel>()
                .ForMember(x => x.PublisherName, y => y.MapFrom(z => z.Publisher != null ? z.Publisher.Name : null))
                .ForMember(x => x.Authors, y => y.MapFrom(z => z.Authors.Select(x => x.Author)))
                .ForMember(x => x.GenreName, y => y.MapFrom(z => z.Genre != null ? z.Genre.Name : null))
                .ReverseMap();
            CreateMap<BorrowingRecord, BorrowingRecordsViewModel>()
                .ReverseMap();
            CreateMap<Publisher, PublisherViewModel>()
                .ForMember(x => x.Addresses, y => y.MapFrom(z => z.Addresses.Select(x => x.Address)))
                .ReverseMap();
            CreateMap<Student, StudentViewModel>()
                .ForMember(x => x.Addresses, y => y.MapFrom(z => z.StudentAddresses.Select(x => x.Address)))
                .ReverseMap();
        }
    }
}
