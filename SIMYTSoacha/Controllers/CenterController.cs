using Microsoft.AspNetCore.Mvc;
using SIMYTSoacha.Model;
using SIMYTSoacha.Services;

namespace SIMYTSoacha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CenterController : ControllerBase
    {
        private readonly ICenterService _centerService;
        public CenterController(ICenterService centerService)
        {
            _centerService = centerService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Ecenters>>> GetAllCenters()
        {
            var centers = await _centerService.GetAllCenterAsync();
            return Ok(centers);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Ecenters>> GetCenterById(int id)
        {
            var center = await _centerService.GetCenterByIdAsync(id);
            if (center == null)
            {
                return NotFound();
            }
            return Ok(center);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateCenter([FromForm] Ecenters ecenters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _centerService.CreateCenterAsync(ecenters);
            return CreatedAtAction(nameof(GetCenterById), new { id = ecenters.EcenterId }, ecenters);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCenter(int id, [FromForm] Ecenters ecenters)
        {

            if (id != ecenters.EcenterId)
            {
                return BadRequest("ID does not exist");
            }

            var existingCenters = await _centerService.GetCenterByIdAsync(id);
            if (existingCenters == null)
            {
                return NotFound();
            }

            existingCenters.Ecenter = ecenters.Ecenter;
            existingCenters.Isdeleted = ecenters.Isdeleted;

            await _centerService.UpdateCenterAsync(existingCenters);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteCenter(int id)
        {
            var center = await _centerService.GetCenterByIdAsync(id);
            if (center == null)
                return NotFound();

            await _centerService.SoftDeleteCenterAsync(id);
            return NoContent();
        }
    }
}
