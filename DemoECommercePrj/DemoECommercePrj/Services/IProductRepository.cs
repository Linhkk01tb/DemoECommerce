using DemoECommercePrj.DTO.Product;

namespace DemoECommercePrj.Services
{
    public interface IProductRepository
    {
        public Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
        public Task<ProductDTO> GetProductByIdAsync(Guid id);
        public Task<Guid> AddProductAsync(ProductDTO productDTO);
        public Task EditProductAsync(Guid id, ProductDTO productDTO);
        public Task DeleteProductAsync(Guid id);
    }
}
