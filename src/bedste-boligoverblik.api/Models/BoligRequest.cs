using System.ComponentModel.DataAnnotations;

namespace bedste_boligoverblik.api.Models
{
    public class BoligRequest
    {
        [Required(ErrorMessage = "User key skal være udfyldt!")]
        public string UserKey { get; init; }

        [Required(ErrorMessage = "Addresse skal være udfyldt!")]
        public string Addresse { get; init; }

        public float X { get; init; }

        public float Y { get; init; }
    }
}