using System.Threading.Tasks;
using AutoMapper;
using bedste_boligoverblik.domain.Mappers;
using bedste_boligoverblik.domain.Models;
using bedste_boligoverblik.proxy.Models;
using bedste_boligoverblik.proxy.Proxies;

namespace bedste_boligoverblik.domain.Facades
{
    public class BeregnFacade : IBeregnFacade
    {
        private readonly IBeregnMapper _beregnMapper;
        private readonly IJyskeBankProxy _jyskeBankProxy;
        private readonly IMapper _mapper;

        public BeregnFacade(IMapper mapper, IBeregnMapper beregnMapper, IJyskeBankProxy jyskeBankProxy)
        {
            _mapper = mapper;
            _beregnMapper = beregnMapper;
            _jyskeBankProxy = jyskeBankProxy;
        }

        public async Task<BeregnResult> Beregn(BeregnQuery query)
        {
            var proxyRequest = _mapper.Map<BeregnProxyRequest>(query);
            var response = await _jyskeBankProxy.BeregnPris(proxyRequest);
            var result = _beregnMapper.MapToResult(response);

            return result;
        }
    }
}