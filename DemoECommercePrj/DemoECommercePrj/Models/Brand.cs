namespace DemoECommercePrj.Models
{
    public class Brand : CommonDate
    {
        /// <summary>
        /// Mã thương hiệu
        /// </summary>
        public int BrandId { get; set; }

        /// <summary>
        /// Tên thương hiệu
        /// </summary>
        public string BrandName { get; set; }

        #region Relationship with Product
        /// <summary>
        /// Quan hệ 1-N giữa Brand và Product
        /// </summary>
        public virtual ICollection<Product> Products { get; set; }

        /// <summary>
        /// Phương thức khởi tạo Brand chứa 1 HashSet Product
        /// </summary>
        public Brand()
        {
            Products = new HashSet<Product>();
        }
        #endregion

    }
}
