using AutoMapper;
using bedste_boligoverblik.domain.Models;
using bedste_boligoverblik.proxy.Models;

namespace bedste_boligoverblik.domain.Mappers
{
    public class LaanberegningMapperProfile : Profile
    {
        public LaanberegningMapperProfile()
        {
            CreateMap<LaanberegningQuery, LaanberegningProxyRequest>()
                .ForMember(
                    dest => dest.BoligType,
                    opt => opt.MapFrom(src => "Hus"));
        }
    }
}