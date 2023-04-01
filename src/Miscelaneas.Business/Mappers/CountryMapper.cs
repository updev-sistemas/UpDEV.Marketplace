using AutoMapper;
using UpDEV.Marketplace.BusinessRules.Miscelaneas.Business.Models;
using UpDEV.Marketplace.Domains.Miscelaneas.Entities;

namespace UpDEV.Marketplace.BusinessRules.Miscelaneas.Business.Mappers
{
    public class CountryMapper : Profile
    {
        public CountryMapper()
        {
            CreateMap<CountryDto, CountryEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt))
                .ReverseMap();
        }
    }
}
