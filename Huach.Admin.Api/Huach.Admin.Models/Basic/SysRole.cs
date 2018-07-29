using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huach.Admin.Models.Basic
{
    [Table("sys_role")]
    public partial class SysRole : ModelBase
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        [StringLength(50), Required]
        public string RoleName { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [StringLength(1000)]
        public string Description { get; set; }
    }
}
