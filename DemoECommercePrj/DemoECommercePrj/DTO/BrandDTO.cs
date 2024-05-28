using DemoECommercePrj.Models;

namespace DemoECommercePrj.DTO
{
    public class BrandDTO : CommonDate
    {
        /// <summary>
        /// Mã thương hiệu
        /// </summary>
        public int BrandId { get; set; }

        /// <summary>
        /// Tên thương hiệu
        /// </summary>
        public string BrandName { get; set; }

    }

}
