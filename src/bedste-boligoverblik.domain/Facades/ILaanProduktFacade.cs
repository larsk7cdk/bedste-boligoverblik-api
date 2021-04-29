using System.Collections.Generic;

namespace bedste_boligoverblik.domain.Facades
{
    public interface ILaanproduktFacade
    {
        IEnumerable<KeyValuePair<string, string>> GetLaanprodukter();
        string GetLaanproduktNavn(string lanproduktKey);
    }
}