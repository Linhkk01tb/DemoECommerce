using DemoECommercePrj.Models;

namespace DemoECommercePrj.DTO.Brand
{
    public class CreateCategoryDTO : CommonDate
    {
        /// <summary>
        /// Tên loại
        /// </summary>
        public string CategoryName { get; set; } = string.Empty;

    }
}
