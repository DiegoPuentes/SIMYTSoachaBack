﻿using Microsoft.AspNetCore.Http.HttpResults;
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
        public async Task<ActionResult> CreateFines([FromBody] RequestFines request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Fines fine = await _finesService.CreateFinesAsync(request.InfractionId, 
                request.MimpositionId, request.MimpositionId, request.Isdeleted);
            return CreatedAtAction(nameof(GetFinesById), new { id = fine.FinesId }, fine);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateFines(int id, [FromBody] RequestFines request)
        {

            var existingFines = await _finesService.GetFinesByIdAsync(id);
            if (existingFines == null)
            {
                return NotFound();
            }

            existingFines.InfractionId = request.InfractionId;
            existingFines.MimpositionId = request.MimpositionId;
            existingFines.ProcedureId = request.ProcedureId;
            existingFines.Isdeleted = request.Isdeleted;

            await _finesService.UpdateFinesAsync(existingFines);
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

        public class RequestFines
        {
            public int InfractionId { get; set; }
            public int MimpositionId { get; set; }
            public int ProcedureId { get; set; }
            public bool Isdeleted { get; set; } = false;
        }
    }
}
