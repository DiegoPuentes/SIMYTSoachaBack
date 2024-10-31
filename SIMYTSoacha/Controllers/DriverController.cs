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
        public async Task<IActionResult> UpdateDriver(int id, [FromForm] int LicenseNumber, int ecenterid,
            DateTime date, int stateid, int restri, int procedureid, bool isdeleted)
        {
            var userTypeId = HttpContext.Session.GetInt32("UserTypeId");

            if (userTypeId == null)
            {
                return Unauthorized("Por favor, inicia sesión para continuar.");
            }
            else
            {
                bool result = await _peopleService.PermissionAsync(userTypeId.Value, 3);
                if (result)
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
                else
                {
                    return Unauthorized("No tiene el permiso, para poder actualizar registros.");
                }
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteDriver(int id)
        {
            var userTypeId = HttpContext.Session.GetInt32("UserTypeId");

            if (userTypeId == null)
            {
                return Unauthorized("Por favor, inicia sesión para continuar.");
            }
            else
            {
                bool result = await _peopleService.PermissionAsync(userTypeId.Value, 2);
                if (result)
                {
                    var driver = await _driverService.GetDriverByIdAsync(id);
                    if (driver == null)
                        return NotFound();

                    await _driverService.SoftDeleteDriverAsync(id);
                    return NoContent();
                }
                else
                {
                    return Unauthorized("No tiene el permiso, para poder eliminar registros.");
                }
            }
        }

        public class RequestDriver
        {
            public required int Nlicense { get; set; }
            public required int EcenterId { get; set; }
            public required DateTime DateIssue { get; set; }
            public int StateId { get; set; }
            public int RestrictionId { get; set; }
            public int ProcedureId { get; set; }
            public bool Isdeleted { get; set; } = false;
        }
    }
}
