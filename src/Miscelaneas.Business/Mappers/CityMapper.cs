using AutoMapper;
using UpDEV.Marketplace.BusinessRules.Miscelaneas.Business.Models;
using UpDEV.Marketplace.Domains.Miscelaneas.Entities;

namespace UpDEV.Marketplace.BusinessRules.Miscelaneas.Business.Mappers
{
    public class CityMapper : Profile
    {
        public CityMapper()
        {
            CreateMap<CityDto, CityEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Perimeter, opt => opt.MapFrom(src => src.Perimeter))
                .ForMember(dest => dest.DDD, opt => opt.MapFrom(src => src.DDD))
                .ForMember(dest => dest.IbgeCode, opt => opt.MapFrom(src => src.IbgeCode))
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Latitude))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Longitude))
                .ForMember(dest => dest.Zone, opt => opt.MapFrom(src => src.Zone))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt))
                .ReverseMap();
        }
    }
}
