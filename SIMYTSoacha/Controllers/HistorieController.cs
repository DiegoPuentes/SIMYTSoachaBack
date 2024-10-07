using Microsoft.AspNetCore.Mvc;
using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;
using SIMYTSoacha.Services;

namespace SIMYTSoacha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorieController : ControllerBase
    {
        private readonly IHistoriesService service;
        public HistorieController(IHistoriesService _service)
        {
            service = _service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Histories>>> GetAllHistories()
        {
            var Histories = await service.GetAllHistoriesAsync();
            return Ok(Histories);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Histories>> GetHistorieById(int id)
        {
            var Histories = await service.GetHistoriesByIdAsync(id);
            if (Histories == null)
            {
                return NotFound();
            }
            return Ok(Histories);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateHistories([FromForm] Histories histories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await service.CreateHistoriesAsync(histories);
            return CreatedAtAction(nameof(GetHistorieById), new { id = histories.HistorieId }, histories);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateHistories(int id, [FromForm] Histories histories)
        {
            if (id != histories.HistorieId)
            {
                return BadRequest("ID does not exist");
            }

            var existingHistories = await service.GetHistoriesByIdAsync(id);
            if (existingHistories == null)
            {
                return NotFound();
            }

            existingHistories.Fnames = histories.Fnames;
            existingHistories.Lname = histories.Lname;
            existingHistories.DtypeId = histories.DtypeId;
            existingHistories.SexId = histories.SexId;
            existingHistories.Ndocument = histories.Ndocument;
            existingHistories.DateBirth = histories.DateBirth;
            existingHistories.UtypeId = histories.UtypeId;
            existingHistories.UserName = histories.UserName;
            existingHistories.Passcode = histories.Passcode;
            existingHistories.Isdeleted = histories.Isdeleted;

            await service.UpdateHistoriesAsync(existingHistories);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteHistories(int id)
        {
            var Histories = await service.GetHistoriesByIdAsync(id);
            if (Histories == null)
                return NotFound();

            await service.SoftDeleteHistoriesAsync(id);
            return NoContent();
        }
    }
}
