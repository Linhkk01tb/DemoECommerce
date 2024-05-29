using DemoECommercePrj.DTO.Product;
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

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await _productRepository.GetAllProductsAsync();
                if (products == null)
                {
                    return NotFound();
                }
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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
                    return NotFound();
                }
                return Ok(productById);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductDTO productDTO)
        {
            try
            {
                var newProduct = await _productRepository.AddProductAsync(productDTO);
                var productById = await _productRepository.GetProductByIdAsync(newProduct);
                return Ok(new
                {
                    Success = true,
                    productById
                });
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]

        public async Task<IActionResult> EditProduct(Guid id, ProductDTO productDTO)
        {
            try
            {
                await _productRepository.EditProductAsync(id, productDTO);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            try
            {
                await _productRepository.DeleteProductAsync(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
