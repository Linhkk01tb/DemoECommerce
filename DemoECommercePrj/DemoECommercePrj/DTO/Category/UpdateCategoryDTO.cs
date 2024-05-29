using DemoECommercePrj.Models;

namespace DemoECommercePrj.DTO.Brand
{
    public class UpdateCategoryDTO: CommonDate
    {
        /// <summary>
        /// Tên loại
        /// </summary>
        public string CategoryName { get; set; } =string.Empty;

    }
}
