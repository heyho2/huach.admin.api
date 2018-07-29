using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huach.Admin.Models.Basic
{
    [Table("sys_menu_role")]
    public partial class SysMenuRole : ModelBase
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        [StringLength(128), Required]
        public string RoleId { get; set; }
        /// <summary>
        /// 菜单ID
        /// </summary>
        [StringLength(128), Required]
        public string MenuId { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [StringLength(1000)]
        public string Description { get; set; }
        /// <summary>
        /// 按钮权限
        /// </summary>
        [StringLength(128), Required]
        public string BottunId { get; set; }
    }
}
