using DemoECommercePrj.Data;
using DemoECommercePrj.DTO;
using DemoECommercePrj.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoECommercePrj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        /// <summary>
        /// Lấy toàn bộ category
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var categories = await _categoryRepository.GetAllCategoriesAsync();
                if (categories == null)
                {
                    return NotFound();
                }
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Lấy 1 category theo id truyền vào
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            try
            {
                var category = await _categoryRepository.GetCategoryByIdAsync(id);
                if (category == null)
                {
                    return NotFound();
                }
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Thêm 1 category vào danh sách
        /// </summary>
        /// <param name="categoryVM"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryDTO categoryVM)
        {
            try
            {
                var newCategory = await _categoryRepository.AddCategoryAsync(categoryVM);
                var category = await _categoryRepository.GetCategoryByIdAsync(newCategory);
                return StatusCode(StatusCodes.Status201Created, new
                {
                    Success = true,
                    category
                });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Chỉnh sửa thông tin của 1 category có id tương ứng với id truyền vào
        /// </summary>
        /// <param name="categoryVM"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> EditCategory(CategoryDTO categoryVM, int id)
        {
            try
            {
                await _categoryRepository.EditCategoryAsync(categoryVM, id);
                return StatusCode(StatusCodes.Status200OK, new
                {
                    Success = true
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Loại bỏ 1 category ra khỏi danh sách
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                await _categoryRepository.DeleteCategoryAsync(id);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
