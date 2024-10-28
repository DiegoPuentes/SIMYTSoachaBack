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
        private readonly IPeopleService _peopleService;
        public TcontactController(ITcontactService tcontactService, IPeopleService peopleService)
        {
            _tcontactService = tcontactService;
            _peopleService = peopleService;
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

            bool result = await _tcontactService.CreateTcontactAsync(typesContacts);

            if (result)
            {
                return CreatedAtAction(nameof(GetTcontactById), new { id = typesContacts.TcontactId },
                typesContacts);
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
        public async Task<IActionResult> UpdateTcontact(int id, [FromForm] TypesContacts typesContacts)
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
                else
                {
                    return Unauthorized("No tiene el permiso, para poder actualizar registros.");
                }
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteTcontact(int id)
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
                    var Tcontact = await _tcontactService.GetTcontactByIdAsync(id);
                    if (Tcontact == null)
                        return NotFound();

                    await _tcontactService.SoftDeleteTcontactAsync(id);
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
