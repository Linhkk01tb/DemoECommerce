namespace DemoECommercePrj.Models
{
    public class OrderDetail : CommonDate
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
        /// Thành tiền
        /// </summary>
        public double TotalPayment() => Product.ProductPrice * BuyQuantity;


        #region Relationship with Product and Order
        public Product Product { get; set; }

        public Order Order { get; set; }
        #endregion
    }
}
