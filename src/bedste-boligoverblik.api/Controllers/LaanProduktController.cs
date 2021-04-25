using System.Net.Mime;
using bedste_boligoverblik.api.Models;
using bedste_boligoverblik.domain.Facades;
using Microsoft.AspNetCore.Mvc;

namespace bedste_boligoverblik.api.Controllers
{
    /// <summary>
    ///     Lånprodukt
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class LaanProduktController : ControllerBase
    {
        /// <summary>
        ///     Henter lånprodukter fra Jyske Bank
        /// </summary>
        [HttpGet]
        [Route("jyskebank")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public LaanProduktResponse Get([FromServices] ILaanProduktFacade laanProduktFacade)
        {
            return new()
            {
                LaanProdukter = laanProduktFacade.GetLaanProdukter()
            };
        }
    }
}