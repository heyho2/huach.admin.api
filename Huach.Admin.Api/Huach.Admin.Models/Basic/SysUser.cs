using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Huach.Admin.Models.Basic
{
    [Table("sys_user")]
    public partial class SysUser : ModelBase
    {
        /// <summary>
        /// 用户名称
        /// </summary>
        [StringLength(20), Required]
        [Column(TypeName = "varchar")]
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [StringLength(18), Required]
        [Column(TypeName = "varchar")]
        public string Password { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        [StringLength(11), Required]
        [Column(TypeName = "varchar")]
        public string Mobile { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        [StringLength(20), Required]
        public string RealName { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        [StringLength(50), Required]
        [Column(TypeName = "varchar")]
        public string Email { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        [StringLength(500), Required]
        [Column(TypeName = "varchar")]
        public string UserImg { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        [StringLength(18)]
        [Column(TypeName = "varchar")]
        public string IDCard { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        [StringLength(500)]
        public string Addr { get; set; }

        /// <summary>
        /// 登陆Ip
        /// </summary>
        [StringLength(20), Required]
        public string IP { get; set; }
        /// <summary>
        /// 父节点
        /// </summary>
        public int ParentId { get; set; }
    }
}
