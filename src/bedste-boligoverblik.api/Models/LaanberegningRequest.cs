using System.ComponentModel.DataAnnotations;

namespace bedste_boligoverblik.api.Models
{
    public class LaanberegningRequest
    {
        [Required(ErrorMessage = "Bolig key skal være udfyldt!")]
        public string BoligKey { get; init; }

        [Required(ErrorMessage = "Produkt skal være udfyldt!")]
        public string Produkt { get; init; }

        [Required(ErrorMessage = "Pris skal være udfyldt!")]
        public long Pris { get; init; }

        [Required(ErrorMessage = "Udbetaling skal være udfyldt!")]
        public long Udbetaling { get; init; }

        [Required(ErrorMessage = "Løbetid skal være udfyldt!")]
        public int Loebetid { get; init; }
        
        public int Afdragsfrihed { get; init; }
        
        public int LoebetidBank { get; init; }
    }
}