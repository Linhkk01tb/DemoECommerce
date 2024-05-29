using DemoECommercePrj.Models;

namespace DemoECommercePrj.DTO.Brand
{
    public class CreateBrandDTO : CommonDate
    {
        /// <summary>
        /// Tên thương hiệu
        /// </summary>
        public string BrandName { get; set; } = string.Empty;

    }
}
