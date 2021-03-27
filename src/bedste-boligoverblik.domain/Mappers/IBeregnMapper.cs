using bedste_boligoverblik.domain.Models;
using bedste_boligoverblik.proxy.Models;

namespace bedste_boligoverblik.domain.Mappers
{
    public interface IBeregnMapper
    {
        BeregnResult MapToResult(BeregnProxyResponse proxyResponse);
    }
}