using Microsoft.AspNetCore.Mvc;
using SIMYTSoacha.Model;
using SIMYTSoacha.Services;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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
        public async Task<ActionResult> CreateTraffic([FromBody] RequestTraffic request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TrafficLicenses traffic = await _trafficService.CreateTrafficLicensesAsync(request.Plate,
                request.VstatesId, request.TserviceId, request.TvehicleId, request.ProcedureId, 
                request.Isdeleted);
            return CreatedAtAction(nameof(GetTrafficById), new { id = traffic.TlicensesId }, traffic);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateTraffic(int id, [FromBody] RequestTraffic request)
        {

            var existingTraffic = await _trafficService.GetTrafficLicensesByIdAsync(id);
            if (existingTraffic == null)
            {
                return NotFound();
            }

            existingTraffic.Plate = request.Plate;
            existingTraffic.VstatesId = request.VstatesId;
            existingTraffic.States = null;
            existingTraffic.TserviceId = request.TserviceId;
            existingTraffic.Services = null;
            existingTraffic.TvehicleId = request.TvehicleId;
            existingTraffic.Vehicles = null;
            existingTraffic.ProcedureId = request.ProcedureId;
            existingTraffic.Procedures = null;
            existingTraffic.Isdeleted = request.Isdeleted;

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

        public class RequestTraffic
        {
            public string Plate { get; set; }
            public int VstatesId { get; set; }
            public int TserviceId { get; set; }
            public int TvehicleId { get; set; }
            public int ProcedureId { get; set; }
            public bool Isdeleted { get; set; } = false;
        }
    }
}
