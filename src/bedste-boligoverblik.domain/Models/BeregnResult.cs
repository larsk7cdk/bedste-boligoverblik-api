using bedste_boligoverblik.domain.Models.Laan;

namespace bedste_boligoverblik.domain.Models
{
    public class BeregnResult
    {
        public Realkreditlaan Realkreditlaan { get; set; }
        public Banklaan? Banklaan { get; set; }
        //public Kreditomkostninger Kreditomkostninger { get; set; }
    }
}