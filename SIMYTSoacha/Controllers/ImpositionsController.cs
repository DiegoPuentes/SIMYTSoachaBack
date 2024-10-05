using Microsoft.AspNetCore.Mvc;
using SIMYTSoacha.Model;
using SIMYTSoacha.Services;

namespace SIMYTSoacha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImpositionsController : ControllerBase
    {
        private readonly IImpositionService _impositionService;
        public ImpositionsController(IImpositionService impositionService)
        {
            _impositionService = impositionService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Mimpositions>>> GetAllImpositions()
        {
            var impos = await _impositionService.GetAllMimpositionsAsync();
            return Ok(impos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Mimpositions>> GetImpositionById(int id)
        {
            var impos = await _impositionService.GetMimpositionsByIdAsync(id);
            if (impos == null)
            {
                return NotFound();
            }
            return Ok(impos);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateImpositions([FromForm] Mimpositions mimpositions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _impositionService.CreateMimpositionsAsync(mimpositions);
            return CreatedAtAction(nameof(GetImpositionById), new { id = mimpositions.MimpositionId }
            , mimpositions);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateImposition(int id, [FromForm] Mimpositions mimpositions)
        {
            if (id != mimpositions.MimpositionId)
            {
                return BadRequest("ID does not exist");
            }

            var existingImpo = await _impositionService.GetMimpositionsByIdAsync(id);
            if (existingImpo == null)
            {
                return NotFound();
            }

            existingImpo.MimpositionName = mimpositions.MimpositionName;
            existingImpo.Isdeleted = mimpositions.Isdeleted;

            await _impositionService.UpdateMimpositionAsync(existingImpo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteImposition(int id)
        {
            var impo = await _impositionService.GetMimpositionsByIdAsync(id);
            if (impo == null)
                return NotFound();

            await _impositionService.SoftDeleteMimpositionsAsync(id);
            return NoContent();
        }
    }
}
