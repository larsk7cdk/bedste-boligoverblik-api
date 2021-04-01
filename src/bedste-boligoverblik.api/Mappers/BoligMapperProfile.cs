using System;
using AutoMapper;
using bedste_boligoverblik.api.Models;
using bedste_boligoverblik.storage.Entities;

namespace bedste_boligoverblik.api.Mappers
{
    public class BoligMapperProfile : Profile
    {
        public BoligMapperProfile()
        {
            CreateMap<BoligRequest, BoligEntity>().ForMember(dest => dest.RowKey, opt =>
                opt.MapFrom(src => Guid.NewGuid().ToString()));

            CreateMap<BoligUpdateRequest, BoligEntity>()
                .ForMember(dest => dest.RowKey, opt =>
                    opt.MapFrom(src => src.RowKey));
        }
    }
}