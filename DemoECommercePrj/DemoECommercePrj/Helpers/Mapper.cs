using AutoMapper;
using DemoECommercePrj.DTO.Brand;
using DemoECommercePrj.DTO.Category;
using DemoECommercePrj.DTO.Product;
using DemoECommercePrj.Models;
using System.Runtime;

namespace DemoECommercePrj.Helpers
{
    public class Mapper : Profile
    {
        public Mapper() {

            #region Map Category
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            #endregion

            #region Map Brand
            CreateMap<Brand, BrandDTO>().ReverseMap();
            CreateMap<Brand, CreateBrandDTO>().ReverseMap();
            #endregion

            #region Map Product
            CreateMap<Product, ProductDTO>().ReverseMap();
            #endregion
        }
    }
}
