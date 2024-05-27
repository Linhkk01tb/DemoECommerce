namespace DemoECommercePrj.Models
{
    public class Product : CommonDate
    {
        /// <summary>
        /// Mã sản phẩm
        /// </summary>
        public Guid ProductId { get; set; }

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
        public string ProductDescription { get; set; }

        #region Relationship with Category
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        #endregion

        /// <summary>
        /// Quan hệ 1-N giữa Product và OrderDetail
        /// </summary>
        //public ICollection<OrderDetail> OrderDetails { get; set; }


        //public Product()
        //{
        //    OrderDetails = new HashSet<OrderDetail>();
        //}
    }
}
