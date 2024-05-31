using DemoECommercePrj.DTO.Product;
using DemoECommercePrj.Helpers;
using DemoECommercePrj.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoECommercePrj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBrandRepository _brandRepository;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository, IBrandRepository brandRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _brandRepository = brandRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await _productRepository.GetAllProductsAsync();
                if (products == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                return StatusCode(StatusCodes.Status200OK, products);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            try
            {
                var productById = await _productRepository.GetProductByIdAsync(id);
                if (productById == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                return StatusCode(StatusCodes.Status200OK, productById);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddProduct(int categoryId, int brandId, CreateProductDTO productDTO)
        {
            try
            {
                if(!await _categoryRepository.HasCategoryAsync(categoryId) || !await _brandRepository.HasBrandAsync(brandId))
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Category or Brand does not exist!");
                }
                var newProduct = productDTO.ToCreateProduct(categoryId, brandId);
                var productById = await _productRepository.AddProductAsync(newProduct);
                return StatusCode(StatusCodes.Status200OK, new
                {
                    Success = true,
                    productById
                });
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpPut("{id}")]

        public async Task<IActionResult> EditProduct(Guid id, ProductDTO productDTO)
        {
            try
            {
                await _productRepository.EditProductAsync(id, productDTO);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            try
            {
                await _productRepository.DeleteProductAsync(id);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}
