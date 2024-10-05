using Microsoft.AspNetCore.Mvc;
using SIMYTSoacha.Model;
using SIMYTSoacha.Services;

namespace SIMYTSoacha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelController :ControllerBase
    {
        private readonly ILevelsService levelService;
        public LevelController(ILevelsService levels)
        {
            levelService = levels;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Levels>>> GetAllLevels()
        {
            var Levels = await levelService.GetAllLevelsAsync();
            return Ok(Levels);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Levels>> GetLevelsById(int id)
        {
            var Levels = await levelService.GetLevelsByIdAsync(id);
            if (Levels == null)
            {
                return NotFound();
            }
            return Ok(Levels);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateLevels([FromForm] Levels levels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await levelService.CreateLevelsAsync(levels);
            return CreatedAtAction(nameof(GetLevelsById), new { id = levels.Id }, levels);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateLevels(int id, [FromForm] Levels levels)
        {
            if (id != levels.Id)
            {
                return BadRequest("ID does not exist");
            }

            var existingLevels = await levelService.GetLevelsByIdAsync(id);
            if (existingLevels == null)
            {
                return NotFound();
            }

            existingLevels.Name = levels.Name;
            existingLevels.IsDeleted = levels.IsDeleted;

            await levelService.UpdateLevelsAsync(existingLevels);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteLevels(int id)
        {
            var Levels = await levelService.GetLevelsByIdAsync(id);
            if (Levels == null)
                return NotFound();

            await levelService.SoftDeleteLevelsAsync(id);
            return NoContent();
        }
    }
}
