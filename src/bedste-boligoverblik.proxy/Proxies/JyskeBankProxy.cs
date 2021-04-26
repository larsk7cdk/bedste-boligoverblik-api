using System.Text;
using System.Threading.Tasks;
using bedste_boligoverblik.core.Helpers;
using bedste_boligoverblik.proxy.Models;
using Newtonsoft.Json;

namespace bedste_boligoverblik.proxy.Proxies
{
    public class JyskeBankProxy : IJyskeBankProxy
    {
        private readonly IHttpClientHelper _httpClientHelper;

        public JyskeBankProxy(IHttpClientHelper httpClientHelper)
        {
            _httpClientHelper = httpClientHelper;
        }

        public async Task<LaanberegningJyskeBankProxyResponse> BeregnPris(LaanberegningProxyRequest request
        )
        {
            var url = new StringBuilder();

            url.Append("https://www.jyskebank.dk");
            url.Append("/portletcontext-calculators/mortgageCalculationByPrice");
            url.Append($"?price={request.Pris}");
            url.Append($"&downPayment={request.Udbetaling}");
            url.Append($"&housingType={request.BoligType}");
            url.Append($"&durationInYears={request.Loebetid}");
            url.Append($"&interestOnlyYears={request.Afdragsfrihed}");
            url.Append($"&durationInYearsBankLoan={request.LoebetidBank}");
            url.Append($"&mortgageProduct={request.Laanprodukt}");

            var result = await _httpClientHelper.GetAsync(url.ToString());
            //var result = await File.ReadAllTextAsync("d:\\temp\\response.json");

            return JsonConvert.DeserializeObject<LaanberegningJyskeBankProxyResponse>(result);
        }
    }
}