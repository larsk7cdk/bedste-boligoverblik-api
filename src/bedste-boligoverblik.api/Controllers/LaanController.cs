using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using Azure;
using bedste_boligoverblik.api.Models;
using bedste_boligoverblik.domain.Facades;
using bedste_boligoverblik.storage.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bedste_boligoverblik.api.Controllers
{
    /// <summary>
    ///     Lån
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class LaanController : ControllerBase
    {
        /// <summary>
        ///     Henter alle lån for en given bolig
        /// </summary>
        [HttpGet("{boligKey}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public IActionResult GetByBoligKey([FromServices] ILaanFacade facade, string boligKey)
        {
            var response = facade.GetByBoligKeyAsync(boligKey);
            return Ok(response);
        }

        /// <summary>
        ///     Henter et lån
        /// </summary>
        [HttpGet]
        [Route("{boligKey}/{rowKey}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IActionResult> GetByRowKey([FromServices] ILaanFacade facade, string rowKey)
        {
            var response = await facade.GetByRowKeyAsync(rowKey);
            return Ok(response);
        }

        /// <summary>
        ///     Opret et Lån
        /// </summary>
        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Create))]
        public async Task<IActionResult> Create(
            [FromServices] IMapper mapper,
            [FromServices] ILaanFacade facade,
            [FromBody] LaanRequest request)
        {
            var entity = mapper.Map<LaanEntity>(request);
            await facade.CreateAsync(entity);

            return Created(string.Empty, "Lån er oprettet");
        }

        
        /// <summary>
        ///     Slet et Lån
        /// </summary>
        [HttpDelete("{rowKey}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<IActionResult> Delete([FromServices] ILaanFacade facade, string rowKey)
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