using AutoMapper;
using bedste_boligoverblik.api.Models;
using bedste_boligoverblik.domain.Models;

namespace bedste_boligoverblik.api.Mappers
{
    public class AdresseMapperProfile : Profile
    {
        public AdresseMapperProfile()
        {
            CreateMap<AdresseRequest, AdresseQuery>();
            CreateMap<AdresseResult, AdresseResponse>();
        }
    }
}