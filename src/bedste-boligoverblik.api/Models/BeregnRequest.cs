using System.ComponentModel.DataAnnotations;

namespace bedste_boligoverblik.api.Models
{
    public class BeregnRequest
    {
        [Required(ErrorMessage = "Produkt skal være udfyldt!")]
        public string Produkt { get; set; }


        public string Pris { get; set; }


        public string Udbetaling { get; set; }

        
        public string Loebetid { get; set; }


        public string Afdragsfrihed { get; set; }


        public string LoebetidBank { get; set; }

        public override string ToString()
        {
            return $"{Produkt}#{Pris}#{Udbetaling}#{Loebetid}#{Afdragsfrihed}#{LoebetidBank}";
        }
    }
}