using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using SIMYTSoacha.Model;
using SIMYTSoacha.Services;

namespace SIMYTSoacha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SexController : ControllerBase
    {
        private readonly ISexService _exService;
        private readonly IPeopleService _peopleService;
        public SexController(ISexService sexService, IPeopleService peopleService)
        {
            _exService = sexService;
            _peopleService = peopleService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Sex>>> GetAllSex()
        {
            var sex = await _exService.GetAllSexAsync();
            return Ok(sex);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Sex>> GetSexById(int id)
        {
            var sex = await _exService.GetSexByIdAsync(id);
            if (sex == null)
            {
                return NotFound();
            }
            return Ok(sex);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateSex([FromForm] Sex sex)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool result = await _exService.CreateSexAsync(sex);

            if (result)
            {
                return CreatedAtAction(nameof(GetSexById), new { id = sex.Id }, sex); 
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
        public async Task<IActionResult> UpdateSex(int id, [FromForm] Sex sex)
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

                    if (id != sex.Id)
                    {
                        return BadRequest("ID does not exist");
                    }

                    var existingSex = await _exService.GetSexByIdAsync(id);
                    if (existingSex == null)
                    {
                        return NotFound();
                    }

                    existingSex.PreferredSex = sex.PreferredSex;
                    existingSex.IsDeleted = sex.IsDeleted;

                    await _exService.UpdateSexAsync(existingSex);
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
        public async Task<IActionResult> SoftDeleteSex(int id)
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
                    var sex = await _exService.GetSexByIdAsync(id);
                    if (sex == null)
                        return NotFound();

                    await _exService.DeleteSexByIdAsync(id);
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
