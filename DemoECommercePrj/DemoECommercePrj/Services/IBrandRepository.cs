using DemoECommercePrj.DTO.Brand;

namespace DemoECommercePrj.Services
{
    public interface IBrandRepository
    {
        public Task<IEnumerable<BrandDTO>> GetAllBrandAsync();

        public Task<BrandDTO?> GetBrandByIdAsync(int id);

        public Task<BrandDTO> AddBrandAsync(CreateBrandDTO brandDTO);

        public Task<BrandDTO?> EditBrandAsync(int id, UpdateBrandDTO brandDTO);

        public Task<BrandDTO?> DeleteBrandAsync(int id);

        public Task<bool> HasBrandAsync(int id);
    }
}
