using System.ComponentModel.DataAnnotations;

namespace bedste_boligoverblik.api.Models
{
    public class BoligRequest
    {
        [Required(ErrorMessage = "User key skal være udfyldt!")]
        public string UserKey { get; init; }

        [Required(ErrorMessage = "Vejnavn skal være udfyldt!")]
        public string Vejnavn { get; init; }

        [Required(ErrorMessage = "Husnummer skal være udfyldt!")]
        public string Husnummer { get; init; }

        [Required(ErrorMessage = "Postnummer skal være udfyldt!")]
        public int Postnummer { get; init; }
    }
}