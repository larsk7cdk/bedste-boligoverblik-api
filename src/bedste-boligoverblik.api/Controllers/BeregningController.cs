using System.Threading.Tasks;
using AutoMapper;
using bedste_boligoverblik.api.Models;
using bedste_boligoverblik.domain.Facades;
using bedste_boligoverblik.domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace bedste_boligoverblik.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class BeregningController : ControllerBase
    {
        /// <summary>
        ///     Laver en beregning
        /// </summary>
        /// <returns>
        /// </returns>
        [HttpGet]
        [Route("beregn")]
        public async Task<IActionResult> Beregn(
            [FromServices] IMapper mapper,
            [FromServices] IBeregnFacade beregnFacade,
            [FromQuery] BeregnRequest request)
        {

            var query = mapper.Map<BeregnQuery>(request);
            var result = await beregnFacade.Beregn(query);
            var response = mapper.Map<BeregnResponse>(result);

            if (request.Produkt == "1")
                return Unauthorized();

            return Ok(response);
        }
    }
}