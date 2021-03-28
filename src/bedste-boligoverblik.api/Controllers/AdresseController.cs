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
    public class AdresseController : ControllerBase
    {
        /// <summary>
        ///     Finder en adress på DAWA
        /// </summary>
        /// <returns>
        ///     Adresse information med geo koordinater
        /// </returns>
        [HttpGet]
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