using System.Collections.Generic;

namespace bedste_boligoverblik.api.Models
{
    public class LaanProdukterResponse
    {
        public IEnumerable<KeyValuePair<string, string>> LaanProdukter { get; set; }
    }
}