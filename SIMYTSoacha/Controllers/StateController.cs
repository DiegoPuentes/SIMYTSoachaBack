using Microsoft.AspNetCore.Mvc;
using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;
using SIMYTSoacha.Services;

namespace SIMYTSoacha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateService _stateService;
        public StateController(IStateService stateService)
        {
            _stateService = stateService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<States>>> GetAllStates()
        {
            var state = await _stateService.GetAllStatesAsync();
            return Ok(state);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Brands>> GetStateById(int id)
        {
            var state = await _stateService.GetStatesByIdAsync(id);
            if (state == null)
            {
                return NotFound();
            }
            return Ok(state);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateState([FromForm] States states)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _stateService.CreateStateAsync(states);
            return CreatedAtAction(nameof(GetStateById), new { id = states.StateId }, states);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateState(int id, [FromForm] States states)
        {
            if (id != states.StateId)
            {
                return BadRequest("ID does not exist");
            }

            var existingStates = await _stateService.GetStatesByIdAsync(id);
            if (existingStates == null)
            {
                return NotFound();
            }

            existingStates.StatesName = states.StatesName;
            existingStates.Isdeleted = states.Isdeleted;

            await _stateService.UpdateStateAsync(existingStates);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteState(int id)
        {
            var state = await _stateService.GetStatesByIdAsync(id);
            if (state == null)
                return NotFound();

            await _stateService.SoftDeleteStateAsync(id);
            return NoContent();
        }
    }
}
