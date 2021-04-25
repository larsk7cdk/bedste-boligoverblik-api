namespace bedste_boligoverblik.domain.Models.JyskeBank
{
    public class Betaling
    {
        public string Dato { get; init; }
        public decimal YdelseFoerSkat { get; init; }
        public decimal YdelseEfterSkat { get; init; }
        public decimal Afdrag { get; init; }
        public decimal Renter { get; init; }
        public decimal Restgaeld { get; init; }
    }
}