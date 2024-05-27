using AutoMapper;
using DemoECommercePrj.Data;
using DemoECommercePrj.DTO;
using DemoECommercePrj.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoECommercePrj.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DemoEcommerceDbContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(DemoEcommerceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddCategoryAsync(CategoryDTO category)
        {
            var newCategory = _mapper.Map<Category>(category);
            category.CreatedDate = DateTime.Now;
            category.ModifiedDate = DateTime.Now;
            _context.Categories.Add(newCategory);
            await _context.SaveChangesAsync();
            return newCategory.CategoryId;
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var deleteCategory = await _context.Categories!.SingleOrDefaultAsync(ct => ct.CategoryId == id);
            if (deleteCategory != null)
            {
                _context.Categories.Remove(deleteCategory);
                await _context.SaveChangesAsync();
            }
        }

        public async Task EditCategoryAsync(CategoryDTO category, int id)
        {
            if(id == category.CategoryId)
            {
                var editCategory = _mapper.Map<Category>(category);
                editCategory.ModifiedDate = DateTime.Now;
                _context.Categories.Update(editCategory);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync()
        {
            var categories = await _context.Categories!.ToListAsync();

            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public async Task<CategoryDTO> GetCategoryByIdAsync(int id)
        {
            var categoryById = await _context.Categories!.FindAsync(id);
            return _mapper.Map<CategoryDTO>(categoryById);
        }

        public async Task<CategoryDTO> GetCategoryByNameAsync(string name)
        {
            var categoryByName = await _context.Categories!.FindAsync(name);
            return _mapper.Map<CategoryDTO>(categoryByName);
        }
    }
}
