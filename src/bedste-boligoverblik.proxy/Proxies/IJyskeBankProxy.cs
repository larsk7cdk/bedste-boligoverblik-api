using System.Threading.Tasks;
using bedste_boligoverblik.proxy.Models;

namespace bedste_boligoverblik.proxy.Proxies
{
    public interface IJyskeBankProxy
    {
        Task<LaanberegningJyskeBankProxyResponse> BeregnPris(LaanberegningProxyRequest request);
    }
}