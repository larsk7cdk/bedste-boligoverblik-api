using System.Collections.Generic;

namespace bedste_boligoverblik.api.Models
{
    public class LaanProduktResponse
    {
        public IEnumerable<KeyValuePair<string, string>> LaanProdukter { get; init; }
    }
}