using System;
using AutoMapper;
using bedste_boligoverblik.api.Models;
using bedste_boligoverblik.storage.Entities;

namespace bedste_boligoverblik.api.Mappers
{
    public class LaanberegningMapperProfile : Profile
    {
        public LaanberegningMapperProfile()
        {
            CreateMap<LaanberegningRequest, LaanberegningEntity>().ForMember(dest => dest.RowKey, opt =>
                opt.MapFrom(src => Guid.NewGuid().ToString()));

            CreateMap<LaanberegningUpdateRequest, LaanberegningEntity>()
                .ForMember(dest => dest.RowKey, opt =>
                    opt.MapFrom(src => src.RowKey));
        }
    }
}