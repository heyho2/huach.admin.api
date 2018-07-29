using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Huach.Admin.Models.Basic
{
    [Table("sys_menu")]
    public class SysMenu : ModelBase
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        [Required]
        [StringLength(100)]
        public string MenuName { get; set; }
        /// <summary>
        /// url
        /// </summary>
        [StringLength(200)]
        public string Url { get; set; }
        /// <summary>
        /// 父节点ID
        /// </summary>
        [StringLength(128)]
        public string ParentId { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [Required]
        public int Sort { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [StringLength(1000)]
        public string Description { get; set; }
    }
}
