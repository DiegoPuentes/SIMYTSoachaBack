using Microsoft.AspNetCore.Mvc;
using SIMYTSoacha.Model;
using SIMYTSoacha.Services;

namespace SIMYTSoacha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UxPController : ControllerBase
    {
        private readonly IUxPService _uxPService;
        public UxPController(IUxPService uxPService)
        {
            _uxPService = uxPService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<UsersXPermissions>>> GetAllUxP()
        {
            var uxp = await _uxPService.GetAllUxPAsync();
            return Ok(uxp);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateUxP([FromForm] int id, int pid, bool isdeleted)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UsersXPermissions user = await _uxPService.CreateUxPAsync(id, pid, isdeleted);
            return Created(nameof(CreateUxP), user);
        }
    }
}
