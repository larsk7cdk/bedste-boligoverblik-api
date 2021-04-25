using AutoMapper;
using bedste_boligoverblik.api.Models;
using bedste_boligoverblik.domain.Models;

namespace bedste_boligoverblik.api.Mappers
{
    public class LaanberegningMapperProfile : Profile
    {
        public LaanberegningMapperProfile()
        {
            CreateMap<LaanberegningRequest, LaanberegningQuery>();
            CreateMap<LaanberegningResult, LaanberegningResponse>();
        }
    }
}