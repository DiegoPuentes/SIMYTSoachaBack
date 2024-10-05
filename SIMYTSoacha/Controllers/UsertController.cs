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
        public UsertController(IUsertService usertService)
        {
            _usertService = usertService;
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

            await _usertService.CreateUserAsync(usersTypes);
            return CreatedAtAction(nameof(GetUsersById), new { id = usersTypes.UtypesId }, usersTypes);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUsers(int id, [FromForm] UsersTypes usersTypes)
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

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteUsers(int id)
        {
            var users = await _usertService.GetUserByIdAsync(id);
            if (users == null)
                return NotFound();

            await _usertService.SoftDeleteUserAsync(id);
            return NoContent();
        }
    }
}
