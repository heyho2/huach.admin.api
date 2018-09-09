using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huach.Admin.ViewModels
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        public int[] Roles { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; set; }
        /// <summary>
        /// 是否管理员
        /// </summary>
        public bool IsManager { get; set; }
        
    }
}
