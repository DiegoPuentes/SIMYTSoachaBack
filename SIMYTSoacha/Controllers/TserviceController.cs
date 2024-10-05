using Microsoft.AspNetCore.Mvc;
using SIMYTSoacha.Model;
using SIMYTSoacha.Services;

namespace SIMYTSoacha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TserviceController : ControllerBase
    {

        private readonly ITserviceService _service;
        public TserviceController(ITserviceService tserviceService)
        {
            _service = tserviceService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TypesServices>>> GetAllTservice()
        {
            var Tservice = await _service.GetAllTserviceAsync();
            return Ok(Tservice);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypesServices>> GetTserviceById(int id)
        {
            var Tservice = await _service.GetTserviceByIdAsync(id);
            if (Tservice == null)
            {
                return NotFound();
            }
            return Ok(Tservice);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateTservice([FromForm] TypesServices typesServices)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _service.CreateTserviceAsync(typesServices);
            return CreatedAtAction(nameof(GetTserviceById), new { id = typesServices.TservicesId },
                typesServices);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateTservice(int id, [FromForm] TypesServices typesServices)
        {
            if (id != typesServices.TservicesId)
            {
                return BadRequest("ID does not exist");
            }

            var existingTservice = await _service.GetTserviceByIdAsync(id);
            if (existingTservice == null)
            {
                return NotFound();
            }

            existingTservice.TservicesName = typesServices.TservicesName;
            existingTservice.Isdeleted = typesServices.Isdeleted;

            await _service.UpdateTserviceAsync(existingTservice);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteTservice(int id)
        {
            var Tservice = await _service.GetTserviceByIdAsync(id);
            if (Tservice == null)
                return NotFound();

            await _service.SoftDeleteTserviceAsync(id);
            return NoContent();
        }
    }
}
