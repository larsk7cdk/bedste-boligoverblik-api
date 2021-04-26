using System.Collections.Generic;

namespace bedste_boligoverblik.domain.Facades
{
    public class LaanProduktFacade : ILaanProduktFacade
    {
        public IEnumerable<KeyValuePair<string, string>> GetLaanProdukter()
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
    }
}