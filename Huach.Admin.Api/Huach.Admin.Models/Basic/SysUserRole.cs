﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Huach.Admin.Models.Basic
{
    [Table("sys_user_role")]
    public class SysUserRole : ModelBase
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        [Required]
        public int RoleId { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        [Required]
        public int UserId { get; set; }
    }
}
