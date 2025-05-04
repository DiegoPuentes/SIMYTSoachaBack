using Microsoft.AspNetCore.Mvc;
using SIMYTSoacha.Model;
using SIMYTSoacha.Services;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMYTSoacha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _driverService;
        private readonly IPeopleService _peopleService;
        public DriverController(IDriverService driverService, IPeopleService peopleService)
        {
            _driverService = driverService;
            _peopleService = peopleService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<DriverLicenses>>> GetAllDrivers()
        {
            var drivers = await _driverService.GetAllDriverAsync();
            return Ok(drivers);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DriverLicenses>> GetDriverById(int id)
        {
            var driver = await _driverService.GetDriverByIdAsync(id);
            if (driver == null)
            {
                return NotFound();
            }
            return Ok(driver);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateDrive([FromBody] RequestDriver request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DriverLicenses driver = await _driverService.CreateDriverAsync(request.Nlicense,
                request.EcenterId, request.DateIssue, request.StateId, request.RestrictionId,
                request.ProcedureId, request.Isdeleted);
            return CreatedAtAction(nameof(GetDriverById), new { id = driver.Id }, driver);

        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateDriver(int id, [FromBody] RequestDriver request)
        {

            var existingDriver = await _driverService.GetDriverByIdAsync(id);
            if (existingDriver == null)
            {
                return NotFound();
            }

            existingDriver.Nlicense = request.Nlicense;
            existingDriver.EcenterId = request.EcenterId;
            existingDriver.Ecenters = null;
            existingDriver.DateIssue = request.DateIssue;
            existingDriver.StateId = request.StateId;
            existingDriver.Procedures = null;
            existingDriver.RestrictionId = request.RestrictionId;
            existingDriver.Restrictions = null;
            existingDriver.ProcedureId = request.ProcedureId;
            existingDriver.Procedures = null;
            existingDriver.Isdeleted = request.Isdeleted;

            await _driverService.UpdateDriverAsync(existingDriver);
            return NoContent();

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteDriver(int id)
        {
            var driver = await _driverService.GetDriverByIdAsync(id);
            if (driver == null)
                return NotFound();

            await _driverService.SoftDeleteDriverAsync(id);
            return NoContent();
        }

        public class RequestDriver
        {
            public required string Nlicense { get; set; }
            public required int EcenterId { get; set; }
            public required DateTime DateIssue { get; set; }
            public int StateId { get; set; }
            public int RestrictionId { get; set; }
            public int ProcedureId { get; set; }
            public bool Isdeleted { get; set; } = false;
        }
    }
}
