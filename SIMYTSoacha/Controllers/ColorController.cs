using Microsoft.AspNetCore.Mvc;
using SIMYTSoacha.Model;
using SIMYTSoacha.Services;

namespace SIMYTSoacha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly IColorService _colorService;
        private readonly IPeopleService _peopleService;
        public ColorController(IColorService colorService, IPeopleService peopleService)
        {
            _colorService = colorService;
            _peopleService = peopleService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Colors>>> GetAllColors()
        {
            var colors = await _colorService.GetAllColorAsync();
            return Ok(colors);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Colors>> GetColorById(int id)
        {
            var colors = await _colorService.GetColorByIdAsync(id);
            if (colors == null)
            {
                return NotFound();
            }
            return Ok(colors);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateBrands([FromForm] Colors colors)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool result = await _colorService.CreateColorAsync(colors);

            if (result)
            {
                return CreatedAtAction(nameof(GetColorById), new { id = colors.Id }, colors);
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
        public async Task<IActionResult> UpdateColor(int id, [FromForm] Colors colors)
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
                    if (id != colors.Id)
                    {
                        return BadRequest("ID does not exist");
                    }

                    var existingColors = await _colorService.GetColorByIdAsync(id);
                    if (existingColors == null)
                    {
                        return NotFound();
                    }

                    existingColors.Name = colors.Name;
                    existingColors.IsDeleted = colors.IsDeleted;

                    await _colorService.UpdateColorAsync(existingColors);
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
        public async Task<IActionResult> SoftDeleteColor(int id)
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
                    var brands = await _colorService.GetColorByIdAsync(id);
                    if (brands == null)
                        return NotFound();

                    await _colorService.SoftDeleteColorAsync(id);
                    return NoContent();
                }
                else
                {
                    return Unauthorized("No tiene el permiso, para poder actualizar registros.");
                }
            }
        }
    }
}
