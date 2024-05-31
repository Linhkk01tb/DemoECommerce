using DemoECommercePrj.Data;
using DemoECommercePrj.DTO.Brand;
using DemoECommercePrj.DTO.Category;
using DemoECommercePrj.Models;
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
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                return StatusCode(StatusCodes.Status200OK,categories);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
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
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                return StatusCode(StatusCodes.Status200OK, category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Thêm 1 category vào danh sách
        /// </summary>
        /// <param name="categoryDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddCategory(CreateCategoryDTO categoryDTO)
        {
            try
            {
                var newCategory = await _categoryRepository.AddCategoryAsync(categoryDTO);
                return StatusCode(StatusCodes.Status201Created, new
                {
                    IsCreated = true,
                    newCategory
                });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }

        }

        /// <summary>
        /// Chỉnh sửa thông tin của 1 category có id tương ứng với id truyền vào
        /// </summary>
        /// <param name="categoryDTO"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> EditCategory(int id, UpdateCategoryDTO categoryDTO)
        {
            try
            {
                var editCategory = await _categoryRepository.EditCategoryAsync(id, categoryDTO);
                return StatusCode(StatusCodes.Status200OK, new
                {
                    IsUpdated = true,
                    editCategory
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
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
                var deleteCategory = await _categoryRepository.DeleteCategoryAsync(id);
                if(deleteCategory == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                return StatusCode(StatusCodes.Status200OK, new
                {
                    IsDeleted = true,
                    deleteCategory
                });
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}
