using Microsoft.AspNetCore.Mvc;
using SIMYTSoacha.Model;
using SIMYTSoacha.Services;

namespace SIMYTSoacha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CenterController : ControllerBase
    {
        private readonly ICenterService _centerService;
        private readonly IPeopleService _peopleService;
        public CenterController(ICenterService centerService, IPeopleService peopleService)
        {
            _centerService = centerService;
            _peopleService = peopleService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Ecenters>>> GetAllCenters()
        {
            var centers = await _centerService.GetAllCenterAsync();
            return Ok(centers);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Ecenters>> GetCenterById(int id)
        {
            var center = await _centerService.GetCenterByIdAsync(id);
            if (center == null)
            {
                return NotFound();
            }
            return Ok(center);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateCenter([FromForm] Ecenters ecenters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool result = await _centerService.CreateCenterAsync(ecenters);

            if (result)
            {
                return CreatedAtAction(nameof(GetCenterById), new { id = ecenters.EcenterId }, ecenters);
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
        public async Task<IActionResult> UpdateCenter(int id, [FromForm] Ecenters ecenters)
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

                    if (id != ecenters.EcenterId)
                    {
                        return BadRequest("ID does not exist");
                    }

                    var existingCenters = await _centerService.GetCenterByIdAsync(id);
                    if (existingCenters == null)
                    {
                        return NotFound();
                    }

                    existingCenters.Ecenter = ecenters.Ecenter;
                    existingCenters.Isdeleted = ecenters.Isdeleted;

                    await _centerService.UpdateCenterAsync(existingCenters);
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
        public async Task<IActionResult> SoftDeleteCenter(int id)
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
                    var center = await _centerService.GetCenterByIdAsync(id);
                    if (center == null)
                        return NotFound();

                    await _centerService.SoftDeleteCenterAsync(id);
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
