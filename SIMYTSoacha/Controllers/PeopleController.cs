
﻿using Microsoft.AspNetCore.Mvc;
using SIMYTSoacha.Model;
using SIMYTSoacha.Services;
using System.Security.Cryptography;


namespace SIMYTSoacha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService _peopleService;
        public static class UserSession
        {
            public static int UserTypeId { get; set; } = 0;
        }

        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<People>>> GetAllPeople()
        {
            var people = await _peopleService.GetAllPeoplesAsync();
            return Ok(people);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<People>> GetPeopleById(int id)
        {
            var people = await _peopleService.GetPeopleByIdAsync(id);
            if (people == null)
            {
                return NotFound();
            }
            return Ok(people);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreatePeople([FromForm] string name, string lnames,
            int dtypeid, string ndocument, int sex, DateTime date, int utypeid, string user,
            string password, bool isdeleted)
        {
            bool permision = await CheckUserPermission();

            if (permision != false)
            {
                return BadRequest("No tienes los permisos");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            People people = await _peopleService.CreatePeopleAsync(name, lnames, dtypeid, ndocument,
                sex, date, utypeid, user, password, isdeleted);
            return CreatedAtAction(nameof(GetPeopleById), new { id = people.PeopleId }, people);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePeople(int id, [FromForm] string name, string lnames,
            int dtypeid, string ndocument, int sex, DateTime date, int utypeid, string user,
            string password, bool isdeleted)
        {

            var existingPeople = await _peopleService.GetPeopleByIdAsync(id);
            if (existingPeople == null)
            {
                return NotFound();
            }

            await _peopleService.UpdatePeopleAsync(name, lnames, dtypeid, ndocument,
                sex, date, utypeid, user, password, isdeleted);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeletePeople(int id)
        {
            var people = await _peopleService.GetPeopleByIdAsync(id);
            if (people == null)
            {
                return NotFound();
            }

            await _peopleService.SoftDeletePeopleAsync(id);
            return NoContent();
        }
        
        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> LoginPeople([FromForm] string userName, [FromForm] string pass)
        {

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(pass))
            {
                return BadRequest("El nombre de usuario o contraseña no pueden estar vacíos.");
            }

            var login = await _peopleService.LoginAsync(userName, pass);

            if (login == null)
            {
                return NotFound("Los datos proporcionados no coinciden con nada.");
            }

            UserSession.UserTypeId = login.UserTypeId;

            return Ok(new { Token = "Validación exitosa", UserTypeId = login.UserTypeId });
        }


        [HttpGet("Permission")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<bool> CheckUserPermission()
        {
            bool hasPermission = await _peopleService.PermissionAsync(UserSession.UserTypeId);

            if (hasPermission)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
