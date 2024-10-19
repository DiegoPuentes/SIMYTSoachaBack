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
        private readonly IPeopleService people;
        public BrandController(IBrandService brandService, IPeopleService peopleService)
        {
            _brandService = brandService;
            people = peopleService;
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

                await _brandService.CreateBrandsAsync(brands);
                return CreatedAtAction(nameof(GetBrandById), new { id = brands.Id }, brands);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateBrands(int id, [FromForm] Brands brands)
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

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteBrands(int id)
        {
            var brands = await _brandService.GetBrandsByIdAsync(id);
            if (brands == null)
                return NotFound();

            await _brandService.SoftDeleteBrandsAsync(id);
            return NoContent();
        }
    }
}
