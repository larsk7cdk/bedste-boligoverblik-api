using System.Collections.Generic;
using System.Linq;

namespace bedste_boligoverblik.domain.Facades
{
    public class LaanproduktFacade : ILaanproduktFacade
    {
        public IEnumerable<KeyValuePair<string, string>> GetLaanprodukter()
        {
            return new[]
            {
                new KeyValuePair<string, string>("JYSKE_RENTELOFT_KORT", "Jyske Renteloft CIBOR3 (1,00%)"),
                new KeyValuePair<string, string>("JYSKE_RENTELOFT_LANG", "Jyske Renteloft CIBOR3 (1,50%)"),
                new KeyValuePair<string, string>("REAL_KREDIT_RTL_100", "Jyske Rentetilpasning F1"),
                new KeyValuePair<string, string>("REAL_KREDIT_VARIABEL_RENTE_2", "Jyske Rentetilpasning F2"),
                new KeyValuePair<string, string>("REAL_KREDIT_VARIABEL_RENTE_3", "Jyske Rentetilpasning F3"),
                new KeyValuePair<string, string>("REAL_KREDIT_VARIABEL_RENTE_4", "Jyske Rentetilpasning F4"),
                new KeyValuePair<string, string>("REAL_KREDIT_VARIABEL_RENTE_5", "Jyske Rentetilpasning F5"),
                new KeyValuePair<string, string>("REAL_KREDIT_VARIABEL_RENTE_6", "Jyske Rentetilpasning F6"),
                new KeyValuePair<string, string>("REAL_KREDIT_FAST_RENTE", "Jyske Fast Rente")
            };
        }

        public string GetLaanproduktNavn(string lanproduktKey)
        {
            var dictionary = GetLaanprodukter().ToDictionary(x => x.Key);
            var found = dictionary.TryGetValue(lanproduktKey, out var value);

            return found ? value.Value : string.Empty;
        }
    }
}