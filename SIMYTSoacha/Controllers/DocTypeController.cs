using Microsoft.AspNetCore.Mvc;
using SIMYTSoacha.Model;
using SIMYTSoacha.Services;

namespace SIMYTSoacha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocTypeController : ControllerBase
    {
        private readonly ContactService _docTypeService;

        public DocTypeController(ContactService docTypeService)
        {
            _docTypeService = docTypeService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<DocumentsTypes>>> GetAllDoc()
        {
            var Dtype = await _docTypeService.GetAllDocAsync();
            return Ok(Dtype);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DocumentsTypes>> GetDocById(int id)
        {
            var Dtype = await _docTypeService.GetDocByIdAsync(id);
            if (Dtype == null)
            {
                return NotFound();
            }
            return Ok(Dtype);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateDoc([FromBody] DocumentsTypes doc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _docTypeService.CreateDocAsync(doc);
            return CreatedAtAction(nameof(GetDocById), new { id = doc.DtypesId }, doc);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateDoc(int id, [FromBody] DocumentsTypes doc)
        {
            if (id != doc.DtypesId)
            {
                return BadRequest("This Doc does not modifie");
            }

            var existingPeople = await _docTypeService.GetDocByIdAsync(id);
            if (existingPeople == null)
            {
                return NotFound("This Doc has not been created");
            }

            await _docTypeService.UpdateContactAsync(doc);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteDoc(int id)
        {
            var people = await _docTypeService.GetDocByIdAsync(id);
            if (people == null)
                return NotFound();

            await _docTypeService.SoftDeleteDocAsync(id);
            return NoContent();
        }
    }
}
