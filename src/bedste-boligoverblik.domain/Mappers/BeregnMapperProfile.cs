using AutoMapper;
using bedste_boligoverblik.domain.Models;
using bedste_boligoverblik.proxy.Models;

namespace bedste_boligoverblik.domain.Mappers
{
    public class BeregnMapperProfile : Profile
    {
        public BeregnMapperProfile()
        {
            CreateMap<BeregnQuery, BeregnProxyRequest>()
                .ForMember(
                    dest => dest.BoligType,
                    opt => opt.MapFrom(src => "Hus"));
        }
    }
}