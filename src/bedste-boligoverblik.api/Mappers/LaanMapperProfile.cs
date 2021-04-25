using System;
using AutoMapper;
using bedste_boligoverblik.api.Models;
using bedste_boligoverblik.storage.Entities;

namespace bedste_boligoverblik.api.Mappers
{
    public class LaanMapperProfile : Profile
    {
        public LaanMapperProfile()
        {
            CreateMap<LaanRequest, LaanEntity>().ForMember(dest => dest.RowKey, opt =>
                opt.MapFrom(src => Guid.NewGuid().ToString()));

            CreateMap<LaanUpdateRequest, LaanEntity>()
                .ForMember(dest => dest.RowKey, opt =>
                    opt.MapFrom(src => src.RowKey));
        }
    }
}