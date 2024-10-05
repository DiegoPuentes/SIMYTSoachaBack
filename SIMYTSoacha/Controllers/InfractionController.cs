using Microsoft.AspNetCore.Mvc;
using SIMYTSoacha.Model;
using SIMYTSoacha.Services;

namespace SIMYTSoacha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfractionController :ControllerBase
    {
        private readonly IInfractionService _infractionService;
        public InfractionController(IInfractionService infractionService)
        {
            _infractionService = infractionService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Infractions>>> GetAllInfractions()
        {
            var infra = await _infractionService.GetAllInfraAsync();
            return Ok(infra);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Infractions>> GetInfractionsById(int id)
        {
            var infra = await _infractionService.GetInfraByIdAsync(id);
            if (infra == null)
            {
                return NotFound();
            }
            return Ok(infra);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateInfractions([FromForm] Infractions infractions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _infractionService.CreateInfraAsync(infractions);
            return CreatedAtAction(nameof(GetInfractionsById), new { id = infractions.InfractionId }
            , infractions);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateInfractions(int id, [FromForm] Infractions infractions)
        {
            if (id != infractions.InfractionId)
            {
                return BadRequest("ID does not exist");
            }

            var existingInfraction = await _infractionService.GetInfraByIdAsync(id);
            if (existingInfraction == null)
            {
                return NotFound();
            }

            existingInfraction.InfractionName = infractions.InfractionName;
            existingInfraction.Isdeleted = infractions.Isdeleted;

            await _infractionService.UpdateInfraAsync(existingInfraction);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteInfractions(int id)
        {
            var infraction = await _infractionService.GetInfraByIdAsync(id);
            if (infraction == null)
                return NotFound();

            await _infractionService.SoftDeleteInfraAsync(id);
            return NoContent();
        }
    }
}
