using AutoMapper;
using DemoECommercePrj.Data;
using DemoECommercePrj.DTO.Brand;
using DemoECommercePrj.DTO.Category;
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

        public async Task<CategoryDTO> AddCategoryAsync(CreateCategoryDTO category)
        {
            var newCategory = _mapper.Map<Category>(category);
            category.CreatedDate = DateTime.UtcNow.ToLocalTime();
            category.ModifiedDate = DateTime.UtcNow.ToLocalTime();
            _context.Categories.Add(newCategory);
            await _context.SaveChangesAsync();
            return _mapper.Map<CategoryDTO>(newCategory);
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

        public async Task<CategoryDTO?> EditCategoryAsync(int id, UpdateCategoryDTO categoryDTO)
        {
            var editCategory = await _context.Categories!.FirstOrDefaultAsync(ct => ct.CategoryId == id);
            if (editCategory != null)
            {
                editCategory.CategoryName = categoryDTO.CategoryName;
                editCategory.ModifiedDate = DateTime.UtcNow.ToLocalTime();
                _context.Categories.Update(editCategory);
                await _context.SaveChangesAsync();
                return _mapper.Map<CategoryDTO>(editCategory);
            }
            return null;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync()
        {
            //Get category + Include list<Product>
            var categories = await _context.Categories!.Include(ct => ct.Products.ToList().OrderBy(pd => pd.ProductId)).ToListAsync();
            //var categories = await _context.Categories!.ToListAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public async Task<CategoryDTO?> GetCategoryByIdAsync(int id)
        {
            var categoryById = await _context.Categories!.Include(ct => ct.Products.ToList().OrderBy(pd => pd.ProductId)).FirstOrDefaultAsync(ct=>ct.CategoryId == id);
            if (categoryById == null)
            {
                return null;
            }
            return _mapper.Map<CategoryDTO>(categoryById);
        }

        public Task<bool> HasCategoryAsync(int id)
        {
            return _context.Categories.AnyAsync(ct => ct.CategoryId == id);
        }
    }
}
