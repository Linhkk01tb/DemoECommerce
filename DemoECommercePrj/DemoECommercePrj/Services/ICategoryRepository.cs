using DemoECommercePrj.DTO;
using DemoECommercePrj.Models;

namespace DemoECommercePrj.Services
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync();

        public Task<CategoryDTO> GetCategoryByIdAsync(int id);

        public Task<CategoryDTO> GetCategoryByNameAsync(string name);

        public Task<int> AddCategoryAsync(CategoryDTO category);

        public Task EditCategoryAsync(CategoryDTO category, int id);

        public Task DeleteCategoryAsync(int id);
    }
}
