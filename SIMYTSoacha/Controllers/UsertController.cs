using Microsoft.AspNetCore.Mvc;
using SIMYTSoacha.Model;
using SIMYTSoacha.Services;

namespace SIMYTSoacha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsertController : ControllerBase
    {
        private readonly IUsertService _usertService;
        private readonly IPeopleService _peopleService;
        public UsertController(IUsertService usertService, IPeopleService peopleService)
        {
            _usertService = usertService;
            _peopleService = peopleService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<UsersTypes>>> GetAllUsers()
        {
            var users = await _usertService.GetAllUserAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UsersTypes>> GetUsersById(int id)
        {
            var users = await _usertService.GetUserByIdAsync(id);
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateUsers([FromForm] UsersTypes usersTypes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool result = await _usertService.CreateUserAsync(usersTypes);

            if (result)
            {
                return CreatedAtAction(nameof(GetUsersById), new { id = usersTypes.UtypesId }, usersTypes);
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
        public async Task<IActionResult> UpdateUsers(int id, [FromForm] UsersTypes usersTypes)
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
                    if (id != usersTypes.UtypesId)
                    {
                        return BadRequest("ID does not exist");
                    }

                    var existingUsers = await _usertService.GetUserByIdAsync(id);
                    if (existingUsers == null)
                    {
                        return NotFound();
                    }

                    existingUsers.UtypesName = usersTypes.UtypesName;
                    existingUsers.Isdeleted = usersTypes.Isdeleted;

                    await _usertService.UpdateUserAsync(existingUsers);
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
        public async Task<IActionResult> SoftDeleteUsers(int id)
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
                    var users = await _usertService.GetUserByIdAsync(id);
                    if (users == null)
                        return NotFound();

                    await _usertService.SoftDeleteUserAsync(id);
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
