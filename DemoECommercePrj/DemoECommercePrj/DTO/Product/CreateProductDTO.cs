using DemoECommercePrj.Models;

namespace DemoECommercePrj.DTO.Product
{
    public class CreateProductDTO :CommonDate
    {
        /// <summary>
        /// Tên sản phẩm
        /// </summary>
        public string ProductName { get; set; } = string.Empty;

        /// <summary>
        /// Số lượng sản phẩm
        /// </summary>
        public int ProductQuantiy { get; set; }

        /// <summary>
        /// Giá sản phẩm
        /// </summary>
        public double ProductPrice { get; set; }

        /// <summary>
        /// Mô tả sản phẩm
        /// </summary>
        public string? ProductDescription { get; set; }
    }
}
