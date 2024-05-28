using DemoECommercePrj.Models;

namespace DemoECommercePrj.DTO
{
    public class OrderDetailDTO : CommonDate
    {
        /// <summary>
        /// Mã đơn hàng
        /// </summary>
        public Guid OrderId { get; set; }

        /// <summary>
        /// Mã sản phẩm
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Số lượng mua
        /// </summary>
        public int BuyQuantity { get; set; }

        /// <summary>
        /// Đơn giá sản phẩm
        /// </summary>
        public double ProductPrice { get; set; }

    }
}
