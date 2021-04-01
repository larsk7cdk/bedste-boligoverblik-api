using System.Net.Mime;
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
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class BeregningController : ControllerBase
    {
        /// <summary>
        ///     Laver en beregning på Jyske Bank
        /// </summary>
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IActionResult> Get(
            [FromServices] IMapper mapper,
            [FromServices] IBeregnFacade beregnFacade,
            [FromQuery] BeregnRequest request)
        {
            var query = mapper.Map<BeregnQuery>(request);
            var result = await beregnFacade.Beregn(query);
            var response = mapper.Map<BeregnResponse>(result);

            return Ok(response);
        }
    }
}