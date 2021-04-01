using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using Azure;
using bedste_boligoverblik.api.Models;
using bedste_boligoverblik.domain.Facades;
using bedste_boligoverblik.storage.Entities;
using Microsoft.AspNetCore.Mvc;

namespace bedste_boligoverblik.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class BoligController : ControllerBase
    {
        /// <summary>
        ///     Henter alle boliger for en given bruger
        /// </summary>
        [HttpGet("{userKey}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public IActionResult GetByUserKey([FromServices] IBoligFacade boligFacade, string userKey)
        {
            var response = boligFacade.GetByUserKeyAsync(userKey);
            return Ok(response);
        }

        /// <summary>
        ///     Henter en bolig
        /// </summary>
        [HttpGet]
        [Route("byrowkey/{rowKey}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IActionResult> GetByRowKey([FromServices] IBoligFacade boligFacade, string rowKey)
        {
            var response = await boligFacade.GetByRowKeyAsync(rowKey);
            return Ok(response);
        }

        /// <summary>
        ///     Opret en bolig
        /// </summary>
        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Create))]
        public async Task<IActionResult> Create(
            [FromServices] IMapper mapper,
            [FromServices] IBoligFacade boligFacade,
            [FromBody] BoligRequest request)
        {
            var entity = mapper.Map<BoligEntity>(request);
            await boligFacade.CreateAsync(entity);

            return Created(string.Empty, "Bolig er oprettet");
        }


        /// <summary>
        ///     Opdater en bolig
        /// </summary>
        [HttpPut]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<IActionResult> Update(
            [FromServices] IMapper mapper,
            [FromServices] IBoligFacade boligFacade,
            [FromBody] BoligUpdateRequest request)
        {
            try
            {
                var entity = mapper.Map<BoligEntity>(request);
                await boligFacade.UpdateAsync(entity);

                return Ok();
            }
            catch (RequestFailedException exception)
            {
                if (exception.Status == 404)
                    return NotFound();

                throw;
            }
        }


        /// <summary>
        ///     Slet en bolig
        /// </summary>
        [HttpDelete("{rowKey}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<IActionResult> Delete([FromServices] IBoligFacade boligFacade, string rowKey)
        {
            try
            {
                await boligFacade.DeleteAsync(rowKey);
                return Ok();
            }
            catch (RequestFailedException exception)
            {
                if (exception.Status == 404)
                    return NotFound();

                throw;
            }
        }
    }
}