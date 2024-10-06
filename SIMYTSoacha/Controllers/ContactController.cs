using Microsoft.AspNetCore.Mvc;
using SIMYTSoacha.Model;
using SIMYTSoacha.Services;

namespace SIMYTSoacha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ContactService _contactService;

        public ContactController(ContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Contacts>>> GetAllContact()
        {
            var contact = await _contactService.GetAllContactAsync();
            return Ok(contact);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Contacts>> GetContactById(int id)
        {
            var contact = await _contactService.GetContactByIdAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateDoc([FromBody] Contacts contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _contactService.CreateContactAsync(contact);
            return CreatedAtAction(nameof(GetContactById), new { id = contact.ContactId }, contact);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateDoc(int id, [FromBody] Contacts contact)
        {
            if (id != contact.ContactId)
            {
                return BadRequest("This contact does not modifie");
            }

            var existingContact = await _contactService.GetContactByIdAsync(id);
            if (existingContact == null)
            {
                return NotFound("This contact has not been created");
            }

            await _contactService.UpdateContactAsync(contact);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteDoc(int id)
        {
            var people = await _contactService.GetContactByIdAsync(id);
            if (people == null)
                return NotFound();

            await _contactService.SoftDeleteContactAsync(id);
            return NoContent();
        }
    }
}
