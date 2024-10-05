using Microsoft.AspNetCore.Mvc;
using SIMYTSoacha.Model;
using SIMYTSoacha.Services;

namespace SIMYTSoacha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TcontactController : ControllerBase
    {
        private readonly ITcontactService _tcontactService;
        public TcontactController(ITcontactService tcontactService)
        {
            _tcontactService = tcontactService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TypesContacts>>> GetAllTcontact()
        {
            var tcontact = await _tcontactService.GetAllTcontactAsync();
            return Ok(tcontact);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypesContacts>> GetTcontactById(int id)
        {
            var Tcontact = await _tcontactService.GetTcontactByIdAsync(id);
            if (Tcontact == null)
            {
                return NotFound();
            }
            return Ok(Tcontact);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateTcontact([FromForm] TypesContacts typesContacts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _tcontactService.CreateTcontactAsync(typesContacts);
            return CreatedAtAction(nameof(GetTcontactById), new { id = typesContacts.TcontactId },
                typesContacts);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateTcontact(int id, [FromForm] TypesContacts typesContacts)
        {
            if (id != typesContacts.TcontactId)
            {
                return BadRequest("ID does not exist");
            }

            var existingTcontact = await _tcontactService.GetTcontactByIdAsync(id);
            if (existingTcontact == null)
            {
                return NotFound();
            }

            existingTcontact.Dtype = typesContacts.Dtype;
            existingTcontact.Isdeleted = typesContacts.Isdeleted;

            await _tcontactService.UpdateTcontactAsync(existingTcontact);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteTcontact(int id)
        {
            var Tcontact = await _tcontactService.GetTcontactByIdAsync(id);
            if (Tcontact == null)
                return NotFound();

            await _tcontactService.SoftDeleteTcontactAsync(id);
            return NoContent();
        }
    }
}
