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
                ProductDescription = productDTO.ProductDescription ?? "",
                CategoryId = categoryId,
                BrandId = brandId
            };
        }
        public static Product ToUpdateProduct(this UpdateProductDTO productDTO)
        {
            var product = new Product();
            product.ProductName = productDTO.ProductName;
            product.ProductPrice = productDTO.ProductPrice;
            product.ProductQuantiy = productDTO.ProductQuantiy;
            product.ProductDescription = productDTO.ProductDescription ?? "";
            return product;
        }
    }
}
