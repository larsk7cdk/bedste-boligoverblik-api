using System.ComponentModel.DataAnnotations;

namespace bedste_boligoverblik.api.Models
{
    public class LaanUpdateRequest : LaanRequest
    {
        [Required(ErrorMessage = "RowKey skal være udfyldt!")]
        public string RowKey { get; set; }
    }
}