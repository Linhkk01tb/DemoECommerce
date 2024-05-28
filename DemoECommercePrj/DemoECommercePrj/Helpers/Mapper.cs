using AutoMapper;
using DemoECommercePrj.DTO;
using DemoECommercePrj.Models;
using System.Runtime;

namespace DemoECommercePrj.Helpers
{
    public class Mapper :Profile
    {
        public Mapper() {
        
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Brand, BrandDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
