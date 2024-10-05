using Microsoft.AspNetCore.Mvc;
using SIMYTSoacha.Model;
using SIMYTSoacha.Services;

namespace SIMYTSoacha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TvehiclesController : ControllerBase
    {
        private readonly ITvehicleService _vehicleService;
        public TvehiclesController(ITvehicleService tvehicleService)
        {
            _vehicleService = tvehicleService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TypesVehicles>>> GetAllTvehicle()
        {
            var Tvehicle = await _vehicleService.GetAllTvehicleAsync();
            return Ok(Tvehicle);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypesVehicles>> GetTvehicleById(int id)
        {
            var Tvehicle = await _vehicleService.GetTvehicleByIdAsync(id);
            if (Tvehicle == null)
            {
                return NotFound();
            }
            return Ok(Tvehicle);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateTvehicle([FromForm] TypesVehicles typesVehicles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _vehicleService.CreateTvehicleAsync(typesVehicles);
            return CreatedAtAction(nameof(GetTvehicleById), new { id = typesVehicles.Id },
                typesVehicles);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateTvehicle(int id, [FromForm] TypesVehicles typesVehicles)
        {
            if (id != typesVehicles.Id)
            {
                return BadRequest("ID does not exist");
            }

            var existingTvehicle = await _vehicleService.GetTvehicleByIdAsync(id);
            if (existingTvehicle == null)
            {
                return NotFound();
            }

            existingTvehicle.Tvehicle = typesVehicles.Tvehicle;
            existingTvehicle.Isdeleted = typesVehicles.Isdeleted;

            await _vehicleService.UpdateTvehicleAsync(existingTvehicle);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteTvehicle(int id)
        {
            var Tvehicle = await _vehicleService.GetTvehicleByIdAsync(id);
            if (Tvehicle == null)
                return NotFound();

            await _vehicleService.SoftDeleteTvehicleAsync(id);
            return NoContent();
        }
    }
}
