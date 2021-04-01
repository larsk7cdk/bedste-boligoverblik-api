using System.Net.Mime;
using bedste_boligoverblik.api.Models;
using bedste_boligoverblik.domain.Facades;
using Microsoft.AspNetCore.Mvc;

namespace bedste_boligoverblik.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class ProduktController : ControllerBase
    {
        /// <summary>
        ///     Henter lånprodukter fra Jyske Bank
        /// </summary>
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public LaanProdukterResponse Get([FromServices] ILaanProdukterFacade laanProdukterFacade)
        {
            return new()
            {
                LaanProdukter = laanProdukterFacade.GetLaanProdukter()
            };
        }
    }
}