using AutoMapper;
using DemoECommercePrj.Data;
using DemoECommercePrj.DTO;
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
        public async Task<int> AddBrandAsync(BrandDTO brandDTO)
        {
            var newBrand = _mapper.Map<Brand>(brandDTO);
            newBrand.CreatedDate = DateTime.Now;
            newBrand.ModifiedDate = DateTime.Now;
            _context.Brands.Add(newBrand); 
            await _context.SaveChangesAsync();
            return newBrand.BrandId;
        }

        public async Task DeleteBrandAsync(int id)
        {
            var deleteBrand = await _context.Brands!.SingleOrDefaultAsync(bd=>bd.BrandId==id);
            _context.Brands.Remove(deleteBrand);
            await _context.SaveChangesAsync();
        }

        public async Task EditBrandAsync(int id, BrandDTO brandDTO)
        {
            if(id == brandDTO.BrandId)
            {
                var editBrand = _mapper.Map<Brand>(brandDTO);
                editBrand.ModifiedDate = DateTime.Now;
                _context.Brands.Update(editBrand);
                await _context.SaveChangesAsync();
            }
            
        }

        public async Task<IEnumerable<BrandDTO>> GetAllBrandAsync()
        {
            var brands = await _context.Brands!.ToListAsync();
            return _mapper.Map<IEnumerable<BrandDTO>>(brands);
        }

        public async Task<BrandDTO> GetBrandByIdAsync(int id)
        {
            var brandById = await _context.Brands!.FindAsync(id);
            return _mapper.Map<BrandDTO>(brandById);
        }
    }
}
