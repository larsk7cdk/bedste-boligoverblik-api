namespace bedste_boligoverblik.domain.Models
{
    public class LaanberegningQuery
    {
        public string Laanprodukt { get; init; }
        public string Pris { get; init; }
        public string Udbetaling { get; init; }
        public string Loebetid { get; init; }
        public string Afdragsfrihed { get; init; }
        public string LoebetidBank { get; init; } 
    }
}