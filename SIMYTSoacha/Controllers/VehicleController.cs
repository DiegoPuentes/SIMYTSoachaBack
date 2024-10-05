using Microsoft.AspNetCore.Mvc;
using SIMYTSoacha.Model;
using SIMYTSoacha.Services;

namespace SIMYTSoacha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        public VehicleController(IVehicleService vehicle)
        {
            _vehicleService = vehicle;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Vehicles>>> GetAllVehicle()
        {
            var vehi = await _vehicleService.GetAllVehiclesAsync();
            return Ok(vehi);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Vehicles>> GetVehicleById(int id)
        {
            var vehi = await _vehicleService.GetVehiclesByIdAsync(id);
            if (vehi == null)
            {
                return NotFound();
            }
            return Ok(vehi);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateVehicle([FromForm] int bid, int cid, string nmotor, int pid, string echasis
            , int mid, bool isdeleted)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Vehicles vehi = await _vehicleService.CreateVehiclesAsync(bid, cid, nmotor, pid, 
                echasis, mid, isdeleted);
            return CreatedAtAction(nameof(GetVehicleById), new { id = vehi.Id }, vehi);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateVehicle(int id, [FromForm] int BrandId, int ColorId,
            string Nmotor, int PeopleId, string Echasis, int Mlineid, bool isdeleted)
        {

            var existingVehicles = await _vehicleService.GetVehiclesByIdAsync(id);
            if (existingVehicles == null)
            {
                return NotFound();
            }

            existingVehicles.BrandId = BrandId;
            existingVehicles.ColorId = ColorId;
            existingVehicles.Nmotor = Nmotor;
            existingVehicles.PeopleId = PeopleId;
            existingVehicles.Echasis = Echasis;
            existingVehicles.MlineId = Mlineid;
            existingVehicles.Isdeleted = isdeleted;

            await _vehicleService.UpdateVehicleAsync(existingVehicles);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteVehicle(int id)
        {
            var vehi = await _vehicleService.GetVehiclesByIdAsync(id);
            if (vehi == null)
                return NotFound();

            await _vehicleService.SoftDeleteVehicleAsync(id);
            return NoContent();
        }
    }
}
