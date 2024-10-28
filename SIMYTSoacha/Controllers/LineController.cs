using Microsoft.AspNetCore.Mvc;
using SIMYTSoacha.Model;
using SIMYTSoacha.Services;

namespace SIMYTSoacha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineController : ControllerBase
    {
        private readonly ILineService _lineService;
        private readonly IPeopleService _peopleService;
        public LineController(ILineService lineService, IPeopleService peopleService)
        {
            _lineService = lineService;
            _peopleService = peopleService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Lines>>> GetAllLines()
        {
            var lines = await _lineService.GetAllLinesAsync();
            return Ok(lines);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Brands>> GetLineById(int id)
        {
            var lines = await _lineService.GetLinesByIdAsync(id);
            if (lines == null)
            {
                return NotFound();
            }
            return Ok(lines);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateLines([FromForm] Lines lines)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool result = await _lineService.CreateLinesAsync(lines);

            if (result)
            {
                return CreatedAtAction(nameof(GetLineById), new { id = lines.Id }, lines);
            }
            else
            {
                return BadRequest("No tienes permisos!");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateLines(int id, [FromForm] Lines lines)
        {
            var userTypeId = HttpContext.Session.GetInt32("UserTypeId");

            if (userTypeId == null)
            {
                return Unauthorized("Por favor, inicia sesión para continuar.");
            }
            else
            {
                bool result = await _peopleService.PermissionAsync(userTypeId.Value, 3);
                if (result)
                {

                    if (id != lines.Id)
                    {
                        return BadRequest("ID does not exist");
                    }

                    var existingLines = await _lineService.GetLinesByIdAsync(id);
                    if (existingLines == null)
                    {
                        return NotFound();
                    }

                    existingLines.Nline = lines.Nline;
                    existingLines.Isdeleted = lines.Isdeleted;

                    await _lineService.UpdateLinesAsync(existingLines);
                    return NoContent();
                }
                else
                {
                    return Unauthorized("No tiene el permiso, para poder actualizar registros.");
                }
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteLines(int id)
        {
            var userTypeId = HttpContext.Session.GetInt32("UserTypeId");

            if (userTypeId == null)
            {
                return Unauthorized("Por favor, inicia sesión para continuar.");
            }
            else
            {
                bool result = await _peopleService.PermissionAsync(userTypeId.Value, 2);
                if (result)
                {
                    var lines = await _lineService.GetLinesByIdAsync(id);
                    if (lines == null)
                        return NotFound();

                    await _lineService.SoftDeleteLinesAsync(id);
                    return NoContent();
                }
                else
                {
                    return Unauthorized("No tiene el permiso, para poder eliminar registros.");
                }
            }
        }
    }
}
