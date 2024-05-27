using DemoECommercePrj.Enum;
namespace DemoECommercePrj.Models
{
    public class Order : CommonDate
    {
        /// <summary>
        /// Mã đơn hàng
        /// </summary>
        public Guid OrderId { get; set; }

        /// <summary>
        /// Tên người nhận
        /// </summary>
        public string ReceivedName {  get; set; }

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
        public OrderStatusCode OrderStatus {  get; set; }

        /// <summary>
        /// Quan hệ 1-N giữa Order và OrderDetail
        /// </summary>
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }


        /// <summary>
        /// Phương thức khởi tạo class Order 1 HashSet OrderDetail
        /// </summary>
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        
    }
}
