using System.Threading.Tasks;
using bedste_boligoverblik.domain.Models;

namespace bedste_boligoverblik.domain.Facades
{
    public interface IBeregnFacade
    {
        Task<BeregnResult> Beregn(BeregnQuery query);
    }
}