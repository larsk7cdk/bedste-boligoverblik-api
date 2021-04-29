using System.ComponentModel.DataAnnotations;

namespace bedste_boligoverblik.api.Models
{
    public class LaanRequest
    {
        [Required(ErrorMessage = "Bolig key skal være udfyldt!")]
        public string BoligKey { get; init; }

        [Required(ErrorMessage = "Lån request skal være udfyldt!")]
        public string Request { get; init; }

        [Required(ErrorMessage = "Resultat skal være udfyldt!")]
        public string Result { get; init; }
    }
}