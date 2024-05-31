using DemoECommercePrj.DTO.Product;
using DemoECommercePrj.Models;

namespace DemoECommercePrj.Helpers
{
    public static class ProductMapper
    {
        public static Product ToCreateProduct(this CreateProductDTO productDTO, int categoryId, int brandId)
        {
            return new Product
            {
                ProductName = productDTO.ProductName,
                ProductPrice = productDTO.ProductPrice,
                ProductQuantiy = productDTO.ProductQuantiy,
                ProductDescription = productDTO.ProductDescription??"",
                CategoryId = categoryId,
                BrandId = brandId
            };
        }
    }
}
