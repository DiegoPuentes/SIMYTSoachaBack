using Microsoft.AspNetCore.Mvc;
using SIMYTSoacha.Model;
using SIMYTSoacha.Services;

namespace SIMYTSoacha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrafficController : ControllerBase
    {
        private readonly ITrafficService _trafficService;
        public TrafficController(ITrafficService traffic)
        {
            _trafficService = traffic;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TrafficLicenses>>> GetAllTraffic()
        {
            var Traffic = await _trafficService.GetAllTrafficLicensesAsync();
            return Ok(Traffic);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TrafficLicenses>> GetTrafficById(int id)
        {
            var Traffic = await _trafficService.GetTrafficLicensesByIdAsync(id);
            if (Traffic == null)
            {
                return NotFound();
            }
            return Ok(Traffic);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateTraffic([FromForm] string plate, int vstate, int tid,
            int vid, int pid, bool isdeleted)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TrafficLicenses traffic = await _trafficService.CreateTrafficLicensesAsync(plate,
                vstate, tid, vid, pid, isdeleted);
            return CreatedAtAction(nameof(GetTrafficById), new { id = traffic.TlicensesId }, traffic);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateTraffic(int id, [FromForm] TrafficLicenses traffic)
        {
            if (id != traffic.TlicensesId)
            {
                return BadRequest("ID does not exist");
            }

            var existingTraffic = await _trafficService.GetTrafficLicensesByIdAsync(id);
            if (existingTraffic == null)
            {
                return NotFound();
            }

            existingTraffic.Plate = traffic.Plate;
            existingTraffic.VstatesId = traffic.VstatesId;
            existingTraffic.TserviceId = traffic.TserviceId;
            existingTraffic.TvehicleId = traffic.TvehicleId;
            existingTraffic.ProcedureId = traffic.ProcedureId;
            existingTraffic.Isdeleted = traffic.Isdeleted;

            await _trafficService.UpdateTrafficLicensesAsync(existingTraffic);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteTraffic(int id)
        {
            var traffic = await _trafficService.GetTrafficLicensesByIdAsync(id);
            if (traffic == null)
                return NotFound();

            await _trafficService.SoftDeleteTrafficLicensesAsync(id);
            return NoContent();
        }
    }
}
