namespace bedste_boligoverblik.domain.Models
{
    public class AdresseResult
    {
        public string Id { get; init; }
        public int Status { get; init; }
        public int Darstatus { get; init; }
        public string Vejkode { get; init; }
        public string Vejnavn { get; init; }
        public string Adresseringsvejnavn { get; init; }
        public string Husnr { get; init; }
        public object Etage { get; init; }
        public object Dør { get; init; }
        public object Supplerendebynavn { get; init; }
        public string Postnr { get; init; }
        public string Postnrnavn { get; init; }
        public object Stormodtagerpostnr { get; init; }
        public object Stormodtagerpostnrnavn { get; init; }
        public string Kommunekode { get; init; }
        public string Adgangsadresseid { get; init; }
        public string X { get; init; }
        public string Y { get; init; }
        public string Href { get; init; }
        public string Betegnelse { get; init; }
    }
}