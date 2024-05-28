using DemoECommercePrj.DTO;
using DemoECommercePrj.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace DemoECommercePrj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandRepository _brandRepository;

        public BrandController(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBrands()
        {
            try
            {
                var brands = await _brandRepository.GetAllBrandAsync();
                return Ok(brands);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandById(int id)
        {
            try
            {
                var brandById = await _brandRepository.GetBrandByIdAsync(id);
                if (brandById == null)
                {
                    return NotFound();
                }
                return Ok(brandById);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddBrand(BrandDTO brandDTO)
        {
            try
            {
                var newBrand = await _brandRepository.AddBrandAsync(brandDTO);
                var brandById = await _brandRepository.GetBrandByIdAsync(newBrand);
                return StatusCode(StatusCodes.Status201Created, new
                {
                    Success = true,
                    brandById
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> EditBrand(int id, BrandDTO brandDTO)
        {
            try
            {
                await _brandRepository.EditBrandAsync(id, brandDTO);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            try
            {
                await _brandRepository.DeleteBrandAsync(id);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
    }

}
