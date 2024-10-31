using Microsoft.AspNetCore.Mvc;
using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;
using SIMYTSoacha.Services;

namespace SIMYTSoacha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LxMController : ControllerBase
    {
        private readonly ILxMService _lxMService;
        public LxMController(ILxMService lxM)
        {
            _lxMService = lxM;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<LevelsxMatches>>> GetAllLxM()
        {
            var lxm = await _lxMService.GetAllLxMAsync();
            return Ok(lxm);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateLxM([FromBody] LxmRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            LevelsxMatches level = await _lxMService.CreateLxMAsync(request.LevelId, request.MatchId, request.Scored, request.isdeleted);
            return Created(nameof(CreateLxM), level);
        }

        public class LxmRequest
        {
            public int LevelId { get; set; }
            public int MatchId { get; set; }
            public int Scored { get; set; }
            public bool isdeleted { get; set; }
        }
    }
}
