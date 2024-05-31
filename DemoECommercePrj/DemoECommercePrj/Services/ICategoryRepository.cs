using DemoECommercePrj.DTO.Brand;
using DemoECommercePrj.DTO.Category;
using DemoECommercePrj.Models;

namespace DemoECommercePrj.Services
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync();

        public Task<CategoryDTO?> GetCategoryByIdAsync(int id);

        public Task<CategoryDTO> AddCategoryAsync(CreateCategoryDTO category);

        public Task<CategoryDTO?> EditCategoryAsync(int id, UpdateCategoryDTO category);

        public Task<CategoryDTO?> DeleteCategoryAsync(int id);

        public Task<bool> HasCategoryAsync(int id);
    }
}
