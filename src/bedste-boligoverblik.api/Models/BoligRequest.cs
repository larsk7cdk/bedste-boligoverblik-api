using System.ComponentModel.DataAnnotations;

namespace bedste_boligoverblik.api.Models
{
    public class BoligRequest
    {
        [Required(ErrorMessage = "User key skal være udfyldt!")]
        public string UserKey { get; init; }

        [Required(ErrorMessage = "Adresse skal være udfyldt!")]
        public string Adresse { get; init; }

        public float X { get; init; }

        public float Y { get; init; }
    }
}