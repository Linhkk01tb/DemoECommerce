using AutoMapper;
using DemoECommercePrj.DTO.Brand;
using DemoECommercePrj.DTO.Category;
using DemoECommercePrj.DTO.Product;
using DemoECommercePrj.Models;
using System.Runtime;

namespace DemoECommercePrj.Helpers
{
    public class ATMapper : Profile
    {
        public ATMapper() {

            #region AutoMap Category
            //CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap().ForMember(ct => ct.Products, ct => ct.MapFrom(ctd => (ProductDTO)ctd.Products));
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            #endregion

            #region AutoMap Brand
            CreateMap<Brand, BrandDTO>().ReverseMap();
            CreateMap<Brand, CreateBrandDTO>().ReverseMap();
            #endregion

            #region AutoMap Product
            CreateMap<Product, ProductDTO>().ReverseMap();
            #endregion
        }
    }
}
