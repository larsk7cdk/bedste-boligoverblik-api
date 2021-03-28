using System.Collections.Generic;

namespace bedste_boligoverblik.domain.Facades
{
    public interface ILaanProdukterFacade
    {
        IEnumerable<KeyValuePair<string, string>> GetLaanProdukter();
    }
}