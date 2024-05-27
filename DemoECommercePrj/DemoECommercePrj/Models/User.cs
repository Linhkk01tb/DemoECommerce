namespace DemoECommercePrj.Models
{
    public class User : CommonDate
    {
        /// <summary>
        /// Mã tài khoản
        /// </summary>
        public int UserId { get; set; }
        
        /// <summary>
        /// Tên tài khoản
        /// </summary>
        public string UserName { get; set; }
        
        /// <summary>
        /// Địa chỉ Email
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        /// Mật khẩu
        /// </summary>
        public string Password { get; set; }
    }
}
