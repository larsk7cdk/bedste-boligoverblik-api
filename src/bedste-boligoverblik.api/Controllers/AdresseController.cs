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
    ///     Adresser fra DAWA
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class AdresseController : ControllerBase
    {
        /// <summary>
        ///     Finder en adress på DAWA
        /// </summary>
        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IActionResult> Get(
            [FromServices] IMapper mapper,
            [FromServices] IAdresseFacade adresseFacade,
            [FromQuery] AdresseRequest request)
        {
            var query = mapper.Map<AdresseQuery>(request);
            var result = await adresseFacade.Soeg(query);
            var response = mapper.Map<AdresseResponse>(result);

            return Ok(response);
        }
    }
}