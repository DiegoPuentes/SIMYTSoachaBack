using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SIMYTSoacha.Model;
using SIMYTSoacha.Services;

namespace SIMYTSoacha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMatchServices matchServices;
        public MatchController(IMatchServices match)
        {
            matchServices = match;
        }

        [HttpGet]
        [EnableCors("AllowAllOrigins")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Matches>>> GetAllMatch()
        {
            var match = await matchServices.GetallMatchAsync();
            return Ok(match);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Brands>> GetMatchById(int id)
        {
            var match = await matchServices.GetMatchesByIdAsync(id);
            if (match == null)
            {
                return NotFound();
            }
            return Ok(match);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [EnableCors("AllowAllOrigins")]
        public async Task<ActionResult> CreateMatch([FromBody] MatchRequest matches)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Matches match = await matchServices.CreateMatchesAsync(matches.PeopleId, 
                matches.Date, matches.isdeleted);
            return CreatedAtAction(nameof(GetMatchById), new { id = match.Id }, match);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateMatch(int id, [FromForm] int Peopleid, DateTime date,
            bool isdeleted)
        {

            var existingMatches = await matchServices.GetMatchesByIdAsync(id);
            if (existingMatches == null)
            {
                return NotFound();
            }

            existingMatches.PeopleId = Peopleid;
            existingMatches.People = null;
            existingMatches.Date = date;
            existingMatches.IsDeleted = isdeleted;

            await matchServices.UpdateMatchesAsync(existingMatches);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteMatch(int id)
        {
            var match = await matchServices.GetMatchesByIdAsync(id);
            if (match == null)
                return NotFound();

            await matchServices.DeleteMatchesAsync(id);
            return NoContent();
        }

        public class MatchRequest
        {
            public int PeopleId { get; set; }
            public DateTime Date { get; set; }
            public bool isdeleted { get; set; }
        }
    }
}
