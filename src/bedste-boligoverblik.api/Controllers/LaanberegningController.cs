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
    public class LaanberegningController : ControllerBase
    {
        /// <summary>
        ///     Henter alle lånberegninger for en given bolig
        /// </summary>
        [HttpGet("{boligKey}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public IActionResult GetByBoligKey([FromServices] ILaanberegningFacade facade, string boligKey)
        {
            var response = facade.GetByBoligKeyAsync(boligKey);
            return Ok(response);
        }

        /// <summary>
        ///     Henter en lånberegning
        /// </summary>
        [HttpGet]
        [Route("byrowkey/{rowKey}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IActionResult> GetByRowKey([FromServices] ILaanberegningFacade facade, string rowKey)
        {
            var response = await facade.GetByRowKeyAsync(rowKey);
            return Ok(response);
        }

        /// <summary>
        ///     Opret en Lånberegning
        /// </summary>
        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Create))]
        public async Task<IActionResult> Create(
            [FromServices] IMapper mapper,
            [FromServices] ILaanberegningFacade facade,
            [FromBody] LaanberegningRequest request)
        {
            var entity = mapper.Map<LaanberegningEntity>(request);
            await facade.CreateAsync(entity);

            return Created(string.Empty, "Lånberegning er oprettet");
        }


        /// <summary>
        ///     Opdater en Lånberegning
        /// </summary>
        [HttpPut]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<IActionResult> Update(
            [FromServices] IMapper mapper,
            [FromServices] ILaanberegningFacade facade,
            [FromBody] LaanberegningUpdateRequest request)
        {
            try
            {
                var entity = mapper.Map<LaanberegningEntity>(request);
                await facade.UpdateAsync(entity);

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
        ///     Slet en Lånberegning
        /// </summary>
        [HttpDelete("{rowKey}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<IActionResult> Delete([FromServices] ILaanberegningFacade facade, string rowKey)
        {
            try
            {
                await facade.DeleteAsync(rowKey);
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