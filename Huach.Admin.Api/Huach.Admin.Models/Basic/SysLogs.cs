using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel;

namespace Huach.Admin.Models.Basic
{
    [Table("sys_logs")]
    public partial class SysLogs : BaseModel
    {
        /// <summary>
        /// 类型
        /// </summary>
        public short Type { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [Column(TypeName = "ntext")]
        public string Content { get; set; }
        /// <summary>
        /// 来源控制器
        /// </summary>
        [StringLength(50), Required, Column(TypeName = "varchar")]
        public string Controller { get; set; }
        /// <summary>
        /// 来源方法
        /// </summary>
        [StringLength(50), Required, Column(TypeName = "varchar")]
        public string Action { get; set; }
        /// <summary>
        /// 来源链接
        /// </summary>
        [StringLength(500), Required, Column(TypeName = "varchar")]
        public string Url { get; set; }
        /// <summary>
        /// 日志类型
        /// </summary>
        public enum TypeEnum
        {
            /// <summary>
            /// 登陆
            /// </summary>
            [Description("登陆日志")]
            Lonin = 1,
            /// <summary>
            /// 错误
            /// </summary>
            [Description("错误日志")]
            Error = 2,
            /// <summary>
            /// 操作
            /// </summary>
            [Description("操作日志")]
            Operating = 3,
        }
    }
}
