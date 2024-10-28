using Microsoft.AspNetCore.Mvc;
using SIMYTSoacha.Model;
using SIMYTSoacha.Services;

namespace SIMYTSoacha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _permissionService;
        private readonly IPeopleService _peopleService;
        public PermissionController(IPermissionService permissionService, IPeopleService peopleService)
        {
            _permissionService = permissionService;
            _peopleService = peopleService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Permissions>>> GetAllPermission()
        {
            var per = await _permissionService.GetPermissionAsync();
            return Ok(per);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Brands>> GetPermissionById(int id)
        {
            var per = await _permissionService.GetPermissionByIdAsync(id);
            if (per == null)
            {
                return NotFound();
            }
            return Ok(per);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreatePermission([FromForm] Permissions permissions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool result = await _permissionService.CreatePermissionAsync(permissions);

            if (result)
            {
                return CreatedAtAction(nameof(GetPermissionById), new { id = permissions.Pid }, 
                    permissions);
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
        public async Task<IActionResult> UpdatePermission(int id, [FromForm] Permissions permissions)
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
                    if (id != permissions.Pid)
                    {
                        return BadRequest("ID does not exist");
                    }

                    var existingPermission = await _permissionService.GetPermissionByIdAsync(id);
                    if (existingPermission == null)
                    {
                        return NotFound();
                    }

                    existingPermission.Permission = permissions.Permission;
                    existingPermission.Isdeleted = permissions.Isdeleted;

                    await _permissionService.UpdatePermissionAsync(existingPermission);
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
        public async Task<IActionResult> SoftDeletePermission(int id)
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
                    var permission = await _permissionService.GetPermissionByIdAsync(id);
                    if (permission == null)
                        return NotFound();

                    await _permissionService.SoftDeletePermissionAsync(id);
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
