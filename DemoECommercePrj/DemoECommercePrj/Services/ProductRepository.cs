using AutoMapper;
using DemoECommercePrj.Data;
using DemoECommercePrj.DTO;
using DemoECommercePrj.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoECommercePrj.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly DemoEcommerceDbContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(DemoEcommerceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Guid> AddProductAsync(ProductDTO productDTO)
        {
            var newProduct = _mapper.Map<Product>(productDTO);
            newProduct.CreatedDate = DateTime.Now;
            newProduct.ModifiedDate =  DateTime.Now;
            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();
            return newProduct.ProductId;

        }

        public async Task DeleteProductAsync(Guid id)
        {
            var deleteProduct = await _context.Products!.SingleOrDefaultAsync(pd => pd.ProductId == id);
            if (deleteProduct != null)
            {
                _context.Products.Remove(deleteProduct);
                await _context.SaveChangesAsync();
            }
        }

        public async Task EditProductAsync(Guid id, ProductDTO productDTO)
        {
            if (id == productDTO.ProductId)
            {
                var editProduct = _mapper.Map<Product>(productDTO);
                editProduct.ModifiedDate = DateTime.Now;
                _context.Products.Update(editProduct);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var products = await _context.Products!.ToListAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO> GetProductByIdAsync(Guid id)
        {
            var productById = await _context.Products!.FindAsync(id);
            return _mapper.Map<ProductDTO>(productById);
        }

        public async Task<ProductDTO> GetProductByNameAsync(string name)
        {
            var productByName = await _context.Products!.FindAsync(name);
            return _mapper.Map<ProductDTO>(productByName);
        }
    }
}
