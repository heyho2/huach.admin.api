using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
