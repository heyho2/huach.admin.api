using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Huach.Admin.Models.Basic
{
    [Table("sys_user_role")]
    public class SysUserRole : ModelBase
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        [StringLength(128), Required]
        public string RoleId { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        [StringLength(128), Required]
        public string UserId { get; set; }
    }
}
