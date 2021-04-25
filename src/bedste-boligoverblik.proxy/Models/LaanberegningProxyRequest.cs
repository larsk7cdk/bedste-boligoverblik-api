namespace bedste_boligoverblik.proxy.Models
{
    public class LaanberegningProxyRequest
    {
        public string Produkt { get; set; }
        public string Pris { get; set; }
        public string Udbetaling { get; set; }
        public string BoligType { get; set; }
        public string Loebetid { get; set; }
        public string Afdragsfrihed { get; set; }
        public string LoebetidBank { get; set; }
    }
}