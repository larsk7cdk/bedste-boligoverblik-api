using AutoMapper;
using bedste_boligoverblik.api.Models;
using bedste_boligoverblik.domain.Models;

namespace bedste_boligoverblik.api.Mappers
{
    public class BeregnMapperProfile : Profile
    {
        public BeregnMapperProfile()
        {
            CreateMap<BeregnRequest, BeregnQuery>();
            CreateMap<BeregnResult, BeregnResponse>();
        }
    }
}