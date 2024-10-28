using Microsoft.AspNetCore.Mvc;
using SIMYTSoacha.Model;
using SIMYTSoacha.Services;

namespace SIMYTSoacha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocTypeController : ControllerBase
    {
        private readonly IDocService _docTypeService;
        private readonly IPeopleService _peopleService;
        public DocTypeController(IDocService docTypeService, IPeopleService peopleService)
        {
            _docTypeService = docTypeService;
            _peopleService = peopleService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<DocumentsTypes>>> GetAllDoc()
        {
            var Dtype = await _docTypeService.GetAllDocAsync();
            return Ok(Dtype);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DocumentsTypes>> GetDocById(int id)
        {
            var Dtype = await _docTypeService.GetDocByIdAsync(id);
            if (Dtype == null)
            {
                return NotFound();
            }
            return Ok(Dtype);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateDoc([FromForm] DocumentsTypes doc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool result = await _docTypeService.CreateDocAsync(doc);

            if (result)
            {
                return CreatedAtAction(nameof(GetDocById), new { id = doc.DtypesId }, doc);
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
        public async Task<IActionResult> UpdateDoc(int id, [FromForm] DocumentsTypes doc)
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
                    if (id != doc.DtypesId)
                    {
                        return BadRequest("This Doc does not modifie");
                    }

                    var existingDoc = await _docTypeService.GetDocByIdAsync(id);
                    if (existingDoc == null)
                    {
                        return NotFound("This Doc has not been created");
                    }

                    existingDoc.Dtype = doc.Dtype;
                    existingDoc.Isdeleted = doc.Isdeleted;

                    await _docTypeService.UpdateDocAsync(existingDoc);
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
        public async Task<IActionResult> SoftDeleteDoc(int id)
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
                    var people = await _docTypeService.GetDocByIdAsync(id);
                    if (people == null)
                        return NotFound();

                    await _docTypeService.SoftDeleteDoctAsync(id);
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
