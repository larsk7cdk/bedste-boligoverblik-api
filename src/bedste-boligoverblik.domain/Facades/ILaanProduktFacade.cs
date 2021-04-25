using System.Collections.Generic;

namespace bedste_boligoverblik.domain.Facades
{
    public interface ILaanProduktFacade
    {
        IEnumerable<KeyValuePair<string, string>> GetLaanProdukter();
    }
}