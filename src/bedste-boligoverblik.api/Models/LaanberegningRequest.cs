using System.ComponentModel.DataAnnotations;

namespace bedste_boligoverblik.api.Models
{
    public class LaanberegningRequest
    {
        [Required(ErrorMessage = "Produkt skal være udfyldt!")]
        public string Produkt { get; init; }

        [Required(ErrorMessage = "Pris skal være udfyldt!")]
        public string Pris { get; init; }

        [Required(ErrorMessage = "Udbetaling skal være udfyldt!")]
        public string Udbetaling { get; init; }

        [Required(ErrorMessage = "Løbetid skal være udfyldt!")]
        public string Loebetid { get; init; }

        public string Afdragsfrihed { get; init; } = "0";

        public string LoebetidBank { get; init; } = "0";
    }
}