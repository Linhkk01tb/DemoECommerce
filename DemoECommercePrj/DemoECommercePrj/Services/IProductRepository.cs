using DemoECommercePrj.DTO.Product;
using DemoECommercePrj.Models;

namespace DemoECommercePrj.Services
{
    public interface IProductRepository
    {
        public Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
        public Task<ProductDTO> GetProductByIdAsync(Guid id);
        public Task<ProductDTO> AddProductAsync(Product product);
        public Task EditProductAsync(Guid id, ProductDTO productDTO);
        public Task DeleteProductAsync(Guid id);
    }
}
