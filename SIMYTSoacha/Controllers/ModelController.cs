using Microsoft.AspNetCore.Mvc;
using SIMYTSoacha.Model;
using SIMYTSoacha.Services;

namespace SIMYTSoacha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly IModelService _modelService;
        public ModelController(IModelService modelService)
        {
            _modelService = modelService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Models>>> GetAllModels()
        {
            var model = await _modelService.GetAllModelsAsync();
            return Ok(model);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Models>> GetModelById(int id)
        {
            var model = await _modelService.GetModelsByIdAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateModels([FromForm] Models models)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _modelService.CreatModelAsync(models);
            return CreatedAtAction(nameof(GetModelById), new { id = models.Id }, models);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateModels(int id, [FromForm] Models models)
        {
            if (id != models.Id)
            {
                return BadRequest("ID does not exist");
            }

            var existingModels = await _modelService.GetModelsByIdAsync(id);
            if (existingModels == null)
            {
                return NotFound();
            }

            existingModels.NModel = models.NModel;
            existingModels.Isdeleted = models.Isdeleted;

            await _modelService.UpdateModelAsync(existingModels);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteModel(int id)
        {
            var model = await _modelService.GetModelsByIdAsync(id);
            if (model == null)
                return NotFound();

            await _modelService.SoftDeleteModelAsync(id);
            return NoContent();
        }
    }
}
