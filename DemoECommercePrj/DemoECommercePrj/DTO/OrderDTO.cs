using DemoECommercePrj.Enum;
using DemoECommercePrj.Models;

namespace DemoECommercePrj.DTO
{
    public class OrderDTO : CommonDate
    {
        /// <summary>
        /// Mã đơn hàng
        /// </summary>
        public Guid OrderId { get; set; }

        /// <summary>
        /// Tên người nhận
        /// </summary>
        public string ReceivedName { get; set; }

        /// <summary>
        /// Ngày đặt hàng
        /// </summary>
        public DateTime OrderDate { get; set; } = DateTime.Now;

        // <summary>
        /// Ngày nhận hàng
        /// </summary>
        public DateTime ReceivedDate { get; set; }

        /// <summary>
        /// Số điện thoại người nhận
        /// </summary>
        public string ReceivedPhoneNumber { get; set; }

        /// <summary>
        /// Email người nhận
        /// </summary>
        public string ReceivedEmail { get; set; }

        /// <summary>
        /// Trạng thái đơn hàng
        /// </summary>
        public OrderStatusCode OrderStatus { get; set; }
    }
}
