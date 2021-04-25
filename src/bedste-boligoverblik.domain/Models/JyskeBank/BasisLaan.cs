using System.Collections.Generic;

namespace bedste_boligoverblik.domain.Models.JyskeBank
{
    public class BasisLaan
    {
        public decimal Restgaeld { get; init; }
        public decimal Loebetid { get; init; }
        public decimal MdlYdelseFoerSkat { get; init; }
        public decimal MdlYdelseEfterSkat { get; init; }
        public decimal MdlAfdrag { get; init; }
        public decimal Tilbagebetaling { get; init; }
        public decimal AaopFoerSkatPct { get; init; }
        public decimal AaopEfterSkatPct { get; init; }
        public decimal DebitorRentePct { get; init; }

        public IEnumerable<Betaling> Betalinger { get; init; }
    }
}