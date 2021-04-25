using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using bedste_boligoverblik.api.Models;
using bedste_boligoverblik.domain.Facades;
using bedste_boligoverblik.domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace bedste_boligoverblik.api.Controllers
{
    /// <summary>
    ///     Lånberegning
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class LaanberegningController : ControllerBase
    {
        /// <summary>
        ///     Laver en beregning hos Jyske Bank
        /// </summary>
        [HttpGet]
        [Route("jyskebank")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IActionResult> Get(
            [FromServices] IMapper mapper,
            [FromServices] ILaanberegningFacade laanberegningFacade,
            [FromQuery] LaanberegningRequest request)
        {
            var query = mapper.Map<LaanberegningQuery>(request);
            var result = await laanberegningFacade.JyskeBankBeregn(query);
            var response = mapper.Map<LaanberegningResponse>(result);

            return Ok(response);
        }
    }
}