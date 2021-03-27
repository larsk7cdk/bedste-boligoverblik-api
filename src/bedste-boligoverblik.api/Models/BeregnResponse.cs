using System.Collections.Generic;
using bedste_boligoverblik.domain.Models.Laan;

namespace bedste_boligoverblik.api.Models
{
    public class BeregnResponse
    {
        public Realkreditlaan Realkreditlaan { get; set; }
        public Banklaan Banklaan { get; set; }
        //public Kreditomkostninger Kreditomkostninger { get; set; }

    }
}