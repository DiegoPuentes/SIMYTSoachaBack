using Microsoft.AspNetCore.Mvc;
using SIMYTSoacha.Model;
using SIMYTSoacha.Services;

namespace SIMYTSoacha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;
        private readonly IPeopleService _peopleService;
        public BrandController(IBrandService brandService, IPeopleService people)
        {
            _brandService = brandService;
            _peopleService = people;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Brands>>> GetAllBrands()
        {
            var brands = await _brandService.GetAllBrandsAsync();
            return Ok(brands);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Brands>> GetBrandById(int id)
        {
            var brands = await _brandService.GetBrandsByIdAsync(id);
            if (brands == null)
            {
                return NotFound();
            }
            return Ok(brands);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateBrands([FromForm] Brands brands)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool result = await _brandService.CreateBrandsAsync(brands);

            if (result)
            {
                return CreatedAtAction(nameof(GetBrandById), new { id = brands.Id }, brands);
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
        public async Task<IActionResult> UpdateBrands(int id, [FromForm] Brands brands)
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
                    if (id != brands.Id)
                    {
                        return BadRequest("ID does not exist");
                    }

                    var existingBrands = await _brandService.GetBrandsByIdAsync(id);
                    if (existingBrands == null)
                    {
                        return NotFound();
                    }

                    existingBrands.Name = brands.Name;
                    existingBrands.IsDeleted = brands.IsDeleted;

                    await _brandService.UpdateBrandsAsync(existingBrands);
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
        public async Task<IActionResult> SoftDeleteBrands(int id)
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
                    var brands = await _brandService.GetBrandsByIdAsync(id);
                    if (brands == null)
                        return NotFound();

                    await _brandService.SoftDeleteBrandsAsync(id);
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
