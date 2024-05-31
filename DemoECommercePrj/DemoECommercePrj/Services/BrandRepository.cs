using AutoMapper;
using DemoECommercePrj.Data;
using DemoECommercePrj.DTO;
using DemoECommercePrj.DTO.Brand;
using DemoECommercePrj.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoECommercePrj.Services
{
    public class BrandRepository : IBrandRepository
    {
        private readonly DemoEcommerceDbContext _context;
        private readonly IMapper _mapper;

        public BrandRepository(DemoEcommerceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<BrandDTO> AddBrandAsync(CreateBrandDTO brandDTO)
        {
            var newBrand = _mapper.Map<Brand>(brandDTO);
            newBrand.CreatedDate = DateTime.Now.ToLocalTime();
            newBrand.ModifiedDate = DateTime.Now.ToLocalTime();
            _context.Brands.Add(newBrand);
            await _context.SaveChangesAsync();
            return _mapper.Map<BrandDTO>(newBrand);
        }

        public async Task<BrandDTO?> DeleteBrandAsync(int id)
        {
            var deleteBrand = await _context.Brands!.SingleOrDefaultAsync(bd => bd.BrandId == id);
            if (deleteBrand != null)
            {
                _context.Brands.Remove(deleteBrand);
                await _context.SaveChangesAsync();
                return  _mapper.Map<BrandDTO>(deleteBrand);
            }
            return null;

        }

        public async Task<BrandDTO?> EditBrandAsync(int id, UpdateBrandDTO brandDTO)
        {
            var editBrand = await _context.Brands!.FindAsync(id);
            if (editBrand != null)
            {
                editBrand.BrandName = brandDTO.BrandName;
                editBrand.ModifiedDate = DateTime.Now.ToLocalTime();
                _context.Brands.Update(editBrand);
                await _context.SaveChangesAsync();
                return _mapper.Map<BrandDTO>(editBrand);
            }
            return null;

        }

        public async Task<IEnumerable<BrandDTO>> GetAllBrandAsync()
        {
            var brands = await _context.Brands!.Include(ct => ct.Products.ToList().OrderBy(pd => pd.ProductId)).ToListAsync();
            return _mapper.Map<IEnumerable<BrandDTO>>(brands);
        }

        public async Task<BrandDTO?> GetBrandByIdAsync(int id)
        {
            var brandById = await _context.Brands!.Include(bd => bd.Products.ToList().OrderBy(pd => pd.ProductId)).FirstOrDefaultAsync(bd => bd.BrandId == id);
            return _mapper.Map<BrandDTO>(brandById);
        }

        public Task<bool> HasBrandAsync(int id)
        {
            return _context.Brands!.AnyAsync(bd => bd.BrandId == id);
        }
    }
}
