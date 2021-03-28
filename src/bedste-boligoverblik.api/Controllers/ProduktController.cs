using bedste_boligoverblik.api.Models;
using bedste_boligoverblik.domain.Facades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bedste_boligoverblik.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProduktController : ControllerBase
    {
        /// <summary>
        ///     Henter lånprodukter fra Jyske Bank
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public LaanProdukterResponse Get([FromServices] ILaanProdukterFacade laanProdukterFacade) =>
            new()
            {
                LaanProdukter = laanProdukterFacade.GetLaanProdukter()
            };
    }
}