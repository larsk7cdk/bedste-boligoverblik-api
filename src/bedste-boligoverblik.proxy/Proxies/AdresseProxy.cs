using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bedste_boligoverblik.core.Extensions;
using bedste_boligoverblik.core.Helpers;
using bedste_boligoverblik.proxy.Models;
using Newtonsoft.Json;

namespace bedste_boligoverblik.proxy.Proxies
{
    public class AdresseProxy : IAdresseProxy
    {
        private readonly IHttpClientHelper _httpClientHelper;

        public AdresseProxy(IHttpClientHelper httpClientHelper)
        {
            _httpClientHelper = httpClientHelper;
        }

        public async Task<AdresseProxyResponse> Soeg(AdresseProxyRequest request)
        {
            var url = new StringBuilder();

            url.Append("https://api.dataforsyningen.dk");
            url.Append("/adresser");
            url.Append($"?vejnavn={request.Vejnavn.CapitalizeFirstLetter()}");
            url.Append($"&husnr={request.Husnummer}");
            url.Append($"&postnr={request.Postnummer}");
            url.Append("&struktur=mini");

            var result = await _httpClientHelper.GetAsync(url.ToString());
            //var result = await File.ReadAllTextAsync("d:\\temp\\adresseMock.json");

            try
            {
                return JsonConvert.DeserializeObject<List<AdresseProxyResponse>>(result)!.First();
            }
            catch
            {
                return null;
            }
        }
    }
}