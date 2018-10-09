using System.ComponentModel.DataAnnotations;

namespace Huach.Admin.ViewModels.Basic
{
    /// <summary>
    /// 登陆
    /// </summary>
    public class LoginRequest
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
    /// <summary>
    /// 登陆响应
    /// </summary>
    public class LoginResponse
    {
        /// <summary>
        /// token
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public int Id { get; set; }
    }
}
