namespace bedste_boligoverblik.domain.Models.JyskeBank
{
    public class SummeringLaan
    {
        public decimal Restgaeld { get; init; }
        public decimal MdlYdelseFoerSkat { get; init; }
        public decimal MdlYdelseEfterSkat { get; init; }
        public decimal MdlAfdrag { get; init; }
        public decimal Tilbagebetaling { get; init; }
    }
}