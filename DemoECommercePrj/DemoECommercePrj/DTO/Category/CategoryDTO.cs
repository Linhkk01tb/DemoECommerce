using DemoECommercePrj.Models;

namespace DemoECommercePrj.DTO.Category
{
    public class CategoryDTO : CommonDate
    {
        /// <summary>
        /// Mã loại
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Tên loại
        /// </summary>
        public string CategoryName { get; set; } = string.Empty;
    }
}
