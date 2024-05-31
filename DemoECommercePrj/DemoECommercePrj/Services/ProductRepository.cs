using AutoMapper;
using DemoECommercePrj.Data;
using DemoECommercePrj.DTO.Product;
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
        public async Task<ProductDTO> AddProductAsync(Product product)
        {

            product.CreatedDate = DateTime.UtcNow.ToLocalTime();
            product.ModifiedDate = DateTime.UtcNow.ToLocalTime();
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDTO>(product);

        }

        public async Task<ProductDTO?> DeleteProductAsync(Guid id)
        {
            var deleteProduct = await _context.Products!.SingleOrDefaultAsync(pd => pd.ProductId == id);
            if (deleteProduct != null)
            {
                _context.Products.Remove(deleteProduct);
                await _context.SaveChangesAsync();
                return _mapper.Map<ProductDTO>(deleteProduct);
            }
            return null;
        }

        public async Task<ProductDTO?> EditProductAsync(Guid id, Product productDTO)
        {
            var editProduct = await _context.Products!.FindAsync(id);
            if (editProduct == null)
            {
                return null;
            }
            editProduct.ProductName = productDTO.ProductName;
            editProduct.ProductDescription = productDTO.ProductDescription;
            editProduct.ProductQuantiy = productDTO.ProductQuantiy;
            editProduct.ProductPrice = productDTO.ProductPrice;
            editProduct.ModifiedDate = DateTime.UtcNow.ToLocalTime();
            _context.Products.Update(editProduct);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDTO>(editProduct);


        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var products = await _context.Products!.ToListAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO?> GetProductByIdAsync(Guid id)
        {
            var productById = await _context.Products!.FindAsync(id);
            return _mapper.Map<ProductDTO>(productById);
        }
    }
}
