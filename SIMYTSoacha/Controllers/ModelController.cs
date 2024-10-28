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
        private readonly IPeopleService _peopleService;
        public ModelController(IModelService modelService, IPeopleService peopleService)
        {
            _modelService = modelService;
            _peopleService = peopleService;
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

            bool result = await _modelService.CreatModelAsync(models);

            if (result)
            {
                return CreatedAtAction(nameof(GetModelById), new { id = models.Id }, models);
            }
            else
            {
                return BadRequest("No tienes permisos!");
            }           
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateModels(int id, [FromForm] Models models)
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
                else
                {
                    return Unauthorized("No tiene el permiso, para poder actualizar registros.");
                }
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteModel(int id)
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
                    var model = await _modelService.GetModelsByIdAsync(id);
                    if (model == null)
                        return NotFound();

                    await _modelService.SoftDeleteModelAsync(id);
                    return NoContent();
                }
                else
                {
                    return Unauthorized("No tiene el permiso, para poder eliminar registros.");
                }
            }
        }
    }
}
