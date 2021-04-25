using bedste_boligoverblik.domain.Models.JyskeBank;

namespace bedste_boligoverblik.api.Models
{
    public class LaanberegningResponse
    {
        public Realkreditlaan Realkreditlaan { get; init; }
        public Banklaan Banklaan { get; init; }
    }
}