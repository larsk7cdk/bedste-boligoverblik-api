using bedste_boligoverblik.domain.Models.JyskeBank;

namespace bedste_boligoverblik.domain.Models
{
    public class LaanberegningResult
    {
        public string LaanproduktNavn { get; init; }
        public Realkreditlaan Realkreditlaan { get; init; }
        public Banklaan Banklaan { get; init; }
        public SummeringLaan SummeringLaan { get; set; }
    }
}