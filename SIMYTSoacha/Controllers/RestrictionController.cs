 using Microsoft.AspNetCore.Mvc;
using SIMYTSoacha.Model;
using SIMYTSoacha.Services;

namespace SIMYTSoacha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestrictionController : ControllerBase
    {
        private readonly IRestriService _restriService;
        private readonly IPeopleService _peopleService;
        public RestrictionController(IRestriService restriService, IPeopleService peopleService)
        {
            _restriService = restriService;
            _peopleService = peopleService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Restrictions>>> GetAllRestri()
        {
            var estri = await _restriService.GetAllRestriAsync();
            return Ok(estri);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Restrictions>> GetRestriById(int id)
        {
            var restri = await _restriService.GetRestriByIdAsync(id);
            if (restri == null)
            {
                return NotFound();
            }
            return Ok(restri);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateRestri([FromForm] Restrictions restrictions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool result = await _restriService.CreateRestriAsync(restrictions);

            if (result)
            {
                return CreatedAtAction(nameof(GetRestriById), new { id = restrictions.RestrictionId },
                restrictions);
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
        public async Task<IActionResult> UpdateRestri(int id, [FromForm] Restrictions restrictions)
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

                    if (id != restrictions.RestrictionId)
                    {
                        return BadRequest("ID does not exist");
                    }

                    var existingRestri = await _restriService.GetRestriByIdAsync(id);
                    if (existingRestri == null)
                    {
                        return NotFound();
                    }

                    existingRestri.RestrictionName = restrictions.RestrictionName;
                    existingRestri.Isdeleted = restrictions.Isdeleted;

                    await _restriService.UpdateRestriAsync(existingRestri);
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
        public async Task<IActionResult> SoftDeleteRestri(int id)
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
                    var restri = await _restriService.GetRestriByIdAsync(id);
                    if (restri == null)
                        return NotFound();

                    await _restriService.SoftDeleteRestriAsync(id);
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
