using System.Threading.Tasks;
using AutoMapper;
using bedste_boligoverblik.domain.Models;
using bedste_boligoverblik.proxy.Models;
using bedste_boligoverblik.proxy.Proxies;

namespace bedste_boligoverblik.domain.Facades
{
    public class AdresseFacade : IAdresseFacade
    {
        private readonly IAdresseProxy _adresseProxy;
        private readonly IMapper _mapper;

        public AdresseFacade(IMapper mapper, IAdresseProxy adresseProxy)
        {
            _mapper = mapper;
            _adresseProxy = adresseProxy;
        }

        public async Task<AdresseResult> Soeg(AdresseQuery query)
        {
            var proxyRequest = _mapper.Map<AdresseProxyRequest>(query);
            var response = await _adresseProxy.Soeg(proxyRequest);
            var result = _mapper.Map<AdresseResult>(response);

            return result;
        }
    }
}