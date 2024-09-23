using Microsoft.AspNetCore.Mvc;
using SIMYTSoacha.Model;
using SIMYTSoacha.Services;

namespace SIMYTSoacha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService _peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<People>>> GetAllPeople()
        {
            var people = await _peopleService.GetAllPeoplesAsync();
            return Ok(people);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<People>> GetPeopleById(int id)
        {
            var people = await _peopleService.GetPeopleByIdAsync(id);
            if (people == null)
            {
                return NotFound();
            }
            return Ok(people);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreatePeople([FromBody] People people)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _peopleService.CreatePeopleAsync(people);
            return CreatedAtAction(nameof(GetPeopleById), new { id = people.PeopleId }, people);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePeople(int id, [FromBody] People people)
        {
            if (id != people.PeopleId)
            {
                return BadRequest();
            }

            var existingPeople = await _peopleService.GetPeopleByIdAsync(id);
            if (existingPeople == null)
            {
                return NotFound();
            }

            await _peopleService.UpdatePeopleAsync(people);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeletePeople(int id)
        {
            var people = await _peopleService.GetPeopleByIdAsync(id);
            if (people == null)
                return NotFound();

            await _peopleService.SoftDeletePeopleAsync(id);
            return NoContent();
        }
    }
}
