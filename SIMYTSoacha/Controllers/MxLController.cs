using Microsoft.AspNetCore.Mvc;
using SIMYTSoacha.Model;
using SIMYTSoacha.Services;

namespace SIMYTSoacha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MxLController : ControllerBase
    {
        private readonly IMxLService _xLService;
        public MxLController(IMxLService mxLService)
        {
            _xLService = mxLService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ModelXLine>>> GetAllMxL()
        {
            var model = await _xLService.GetAllAsync();
            return Ok(model);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateMxL([FromForm] ModelXLine modelXLine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _xLService.CreateAsync(modelXLine);
            return Created(nameof(CreateMxL), modelXLine);
        }
    }
}
