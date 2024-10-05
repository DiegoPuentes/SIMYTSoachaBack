using Microsoft.AspNetCore.Mvc;
using SIMYTSoacha.Model;
using SIMYTSoacha.Services;

namespace SIMYTSoacha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestrictionController : ControllerBase
    {
        private readonly IRestriService _restriService;
        public RestrictionController(IRestriService restriService)
        {
            _restriService = restriService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Restrictions>>> GetAllRestri()
        {
            var estri = await _restriService.GetAllRestriAsync();
            return Ok(estri);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Restrictions>> GetRestriById(int id)
        {
            var restri = await _restriService.GetRestriByIdAsync(id);
            if (restri == null)
            {
                return NotFound();
            }
            return Ok(restri);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateRestri([FromForm] Restrictions restrictions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _restriService.CreateRestriAsync(restrictions);
            return CreatedAtAction(nameof(GetRestriById), new { id = restrictions.RestrictionId }, 
                restrictions);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateRestri(int id, [FromForm] Restrictions restrictions)
        {
            if (id != restrictions.RestrictionId)
            {
                return BadRequest("ID does not exist");
            }

            var existingRestri = await _restriService.GetRestriByIdAsync(id);
            if (existingRestri == null)
            {
                return NotFound();
            }

            existingRestri.RestrictionName = restrictions.RestrictionName;
            existingRestri.Isdeleted = restrictions.Isdeleted;

            await _restriService.UpdateRestriAsync(existingRestri);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteRestri(int id)
        {
            var restri = await _restriService.GetRestriByIdAsync(id);
            if (restri == null)
                return NotFound();

            await _restriService.SoftDeleteRestriAsync(id);
            return NoContent();
        }
    }
}
