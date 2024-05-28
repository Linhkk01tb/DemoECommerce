using DemoECommercePrj.DTO;

namespace DemoECommercePrj.Services
{
    public interface IBrandRepository
    {
        public Task<IEnumerable<BrandDTO>> GetAllBrandAsync();

        public Task<BrandDTO> GetBrandByIdAsync(int id);

        public Task<int> AddBrandAsync(BrandDTO brandDTO);

        public Task EditBrandAsync(int id, BrandDTO brandDTO);

        public Task DeleteBrandAsync(int id);
    }
}
