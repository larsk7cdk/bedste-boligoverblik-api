using System.ComponentModel.DataAnnotations;

namespace bedste_boligoverblik.api.Models
{
    public class LaanberegningUpdateRequest : LaanberegningRequest
    {
        [Required(ErrorMessage = "RowKey skal være udfyldt!")]
        public string RowKey { get; set; }
    }
}