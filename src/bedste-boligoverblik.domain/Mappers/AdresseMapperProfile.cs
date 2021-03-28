using AutoMapper;
using bedste_boligoverblik.domain.Models;
using bedste_boligoverblik.proxy.Models;

namespace bedste_boligoverblik.domain.Mappers
{
    public class AdresseMapperProfile : Profile
    {
        public AdresseMapperProfile()
        {
            CreateMap<AdresseQuery, AdresseProxyRequest>();
            CreateMap<AdresseProxyResponse, AdresseResult>();
        }
    }
}