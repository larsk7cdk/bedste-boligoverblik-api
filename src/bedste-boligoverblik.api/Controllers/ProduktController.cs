using bedste_boligoverblik.api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bedste_boligoverblik.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduktController : ControllerBase
    {
        /// <summary>
        ///     Henter produkter der kan beregnes på
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ProdukterResponse Get()
        {
            return new() {Navn = "F1"};
        }
    }
}