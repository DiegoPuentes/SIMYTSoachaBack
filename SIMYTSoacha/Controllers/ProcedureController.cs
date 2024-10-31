using Microsoft.AspNetCore.Mvc;
using SIMYTSoacha.Model;
using SIMYTSoacha.Services;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcedureController : ControllerBase
    {
        private readonly IProcedureService _procedureService;
        public ProcedureController(IProcedureService procedureService)
        {
            _procedureService = procedureService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Procedures>>> GetAllProcedures()
        {
            var proce = await _procedureService.GetAllProceduresAsync();
            return Ok(proce);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Brands>> GetProcedureById(int id)
        {
            var proce = await _procedureService.GetProceduresByIdAsync(id);
            if (proce == null)
            {
                return NotFound();
            }
            return Ok(proce);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateProcedure([FromBody] RequestProcedure request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Procedures pro = await _procedureService.CreateProceduresAsync(request.Description, 
                request.StateId, request.RequestId, request.Isdeleted);
            return CreatedAtAction(nameof(GetProcedureById), new { id = pro.ProcedureId },
                pro);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateProcedure(int id, [FromForm] int procedure, int stateid
            , int requestid, bool isdeleted)
        {
            var existingProcedure = await _procedureService.GetProceduresByIdAsync(id);
            if (existingProcedure == null)
            {
                return NotFound();
            }

            existingProcedure.ProcedureId = procedure;
            existingProcedure.StateId = stateid;
            existingProcedure.States = null;
            existingProcedure.RequestId = requestid;
            existingProcedure.Requests = null;
            existingProcedure.Isdeleted = isdeleted;

            await _procedureService.UpdateProceduresAsync(existingProcedure);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteProcedure(int id)
        {
            var proce = await _procedureService.GetProceduresByIdAsync(id);
            if (proce == null)
                return NotFound();

            await _procedureService.SoftDeleteProceduresAsync(id);
            return NoContent();
        }
    }

    public class RequestProcedure
    {
        public string Description { get; set; }
        public int StateId { get; set; }
        public int RequestId { get; set; }
        public bool Isdeleted { get; set; } = false;
    }
}
