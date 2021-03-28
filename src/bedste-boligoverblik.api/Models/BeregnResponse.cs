using bedste_boligoverblik.domain.Models.Laan;

namespace bedste_boligoverblik.api.Models
{
    public class BeregnResponse
    {
        public Realkreditlaan Realkreditlaan { get; init; }
        public Banklaan Banklaan { get; init; }
    }
}