using System.Threading.Tasks;
using AutoMapper;
using bedste_boligoverblik.domain.Mappers;
using bedste_boligoverblik.domain.Models;
using bedste_boligoverblik.proxy.Models;
using bedste_boligoverblik.proxy.Proxies;

namespace bedste_boligoverblik.domain.Facades
{
    public class LaanberegningFacade : ILaanberegningFacade
    {
        private readonly IJyskeBankProxy _jyskeBankProxy;
        private readonly ILaanberegningMapper _laanberegningMapper;
        private readonly IMapper _mapper;

        public LaanberegningFacade(IMapper mapper, ILaanberegningMapper laanberegningMapper,
            IJyskeBankProxy jyskeBankProxy)
        {
            _mapper = mapper;
            _laanberegningMapper = laanberegningMapper;
            _jyskeBankProxy = jyskeBankProxy;
        }

        public async Task<LaanberegningResult> JyskeBankBeregn(LaanberegningQuery query)
        {
            var request = _mapper.Map<LaanberegningProxyRequest>(query);
            var response = await _jyskeBankProxy.BeregnPris(request);
            var result = _laanberegningMapper.MapToResultFromJyskeBank(request, response);

            return result;
        }
    }
}