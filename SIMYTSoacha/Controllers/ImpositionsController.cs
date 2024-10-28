using Microsoft.AspNetCore.Mvc;
using SIMYTSoacha.Model;
using SIMYTSoacha.Services;

namespace SIMYTSoacha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImpositionsController : ControllerBase
    {
        private readonly IImpositionService _impositionService;
        private readonly IPeopleService _peopleService;
        public ImpositionsController(IImpositionService impositionService,
            IPeopleService peopleService)
        {
            _impositionService = impositionService;
            _peopleService = peopleService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Mimpositions>>> GetAllImpositions()
        {
            var impos = await _impositionService.GetAllMimpositionsAsync();
            return Ok(impos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Mimpositions>> GetImpositionById(int id)
        {
            var impos = await _impositionService.GetMimpositionsByIdAsync(id);
            if (impos == null)
            {
                return NotFound();
            }
            return Ok(impos);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateImpositions([FromForm] Mimpositions mimpositions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool result = await _impositionService.CreateMimpositionsAsync(mimpositions);

            if (result)
            {

                return CreatedAtAction(nameof(GetImpositionById), new { id = mimpositions.MimpositionId }
                , mimpositions);
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
        public async Task<IActionResult> UpdateImposition(int id, [FromForm] Mimpositions mimpositions)
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
                    if (id != mimpositions.MimpositionId)
                    {
                        return BadRequest("ID does not exist");
                    }

                    var existingImpo = await _impositionService.GetMimpositionsByIdAsync(id);
                    if (existingImpo == null)
                    {
                        return NotFound();
                    }

                    existingImpo.MimpositionName = mimpositions.MimpositionName;
                    existingImpo.Isdeleted = mimpositions.Isdeleted;

                    await _impositionService.UpdateMimpositionAsync(existingImpo);
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
        public async Task<IActionResult> SoftDeleteImposition(int id)
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
                    var impo = await _impositionService.GetMimpositionsByIdAsync(id);
                    if (impo == null)
                        return NotFound();

                    await _impositionService.SoftDeleteMimpositionsAsync(id);
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
