using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SIMYTSoacha.Model;
using SIMYTSoacha.Services;

namespace SIMYTSoacha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinesController : ControllerBase
    {
        private readonly IFinesService _finesService;
        public FinesController(IFinesService finesService)
        {
            _finesService = finesService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Fines>>> GetAllFines()
        {
            var fines = await _finesService.GetAllFinesAsync();
            return Ok(fines);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Fines>> GetFinesById(int id)
        {
            var fines = await _finesService.GetFinesByIdAsync(id);
            if (fines == null)
            {
                return NotFound();
            }
            return Ok(fines);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateFines([FromForm] int id, int mid, int pid, bool isdeleted)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Fines fine = await _finesService.CreateFinesAsync(id, mid, pid, isdeleted);
            return CreatedAtAction(nameof(GetFinesById), new { id = fine.FinesId }, fine);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateFines(int id, [FromForm] int infractionid, int mimpositionid, 
            int procedureid, bool isdeleted)
        {

            var existingFines = await _finesService.GetFinesByIdAsync(id);
            if (existingFines == null)
            {
                return NotFound();
            }

            existingFines.InfractionId = infractionid;
            existingFines.MimpositionId = mimpositionid;
            existingFines.ProcedureId = procedureid;
            existingFines.Isdeleted = isdeleted;

            await _finesService.UpdateFinesAsync(infractionid, mimpositionid, procedureid, isdeleted);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteBrands(int id)
        {
            var brands = await _finesService.GetFinesByIdAsync(id);
            if (brands == null)
                return NotFound();

            await _finesService.SoftDeleteFinesAsync(id);
            return NoContent();
        }
    }
}
