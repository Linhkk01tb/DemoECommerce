using DemoECommercePrj.Data;
using DemoECommercePrj.DTO.Brand;
using DemoECommercePrj.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                return StatusCode(StatusCodes.Status200OK, brands);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
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
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                return StatusCode(StatusCodes.Status200OK, brandById);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddBrand(CreateBrandDTO brandDTO)
        {
            try
            {
                var newBrand = await _brandRepository.AddBrandAsync(brandDTO);
                return StatusCode(StatusCodes.Status201Created, new
                {
                    Success = true,
                    newBrand
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> EditBrand(int id, UpdateBrandDTO brandDTO)
        {
            try
            {
                var editBrand = await _brandRepository.EditBrandAsync(id, brandDTO);
                return StatusCode(StatusCodes.Status200OK, new
                {
                    Success = true,
                    editBrand
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            try
            {
                await _brandRepository.DeleteBrandAsync(id);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }

}
