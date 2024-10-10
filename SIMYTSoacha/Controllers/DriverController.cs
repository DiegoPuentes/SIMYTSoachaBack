using Microsoft.AspNetCore.Mvc;
using SIMYTSoacha.Model;
using SIMYTSoacha.Services;

namespace SIMYTSoacha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _driverService;
        public DriverController(IDriverService driverService)
        {
            _driverService = driverService; 
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
        public async Task<ActionResult> CreateDrive([FromForm] int nlicense, int Eid, DateTime date,
            int Sid, int Rid, int Pid, bool isdeleted)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            DriverLicenses driver = await _driverService.CreateDriverAsync(nlicense, Eid, date, 
                Sid, Rid, Pid, isdeleted);
            return CreatedAtAction(nameof(GetDriverById), new { id = driver.Id }, driver);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateDriver(int id, [FromForm] int LicenseNumber, int ecenterid,
            DateTime date, int stateid, int restri, int procedureid, bool isdeleted)
        {
            

            var existingDriver = await _driverService.GetDriverByIdAsync(id);
            if (existingDriver == null)
            {
                return NotFound();
            }

            existingDriver.Nlicense = LicenseNumber;
            existingDriver.EcenterId = ecenterid;
            existingDriver.Ecenters = null;
            existingDriver.DateIssue = date;
            existingDriver.StateId = stateid;
            existingDriver.Procedures = null;
            existingDriver.RestrictionId = restri;
            existingDriver.Restrictions = null;
            existingDriver.ProcedureId = procedureid;
            existingDriver.Procedures = null;
            existingDriver.Isdeleted = isdeleted;
            
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
    }
}
