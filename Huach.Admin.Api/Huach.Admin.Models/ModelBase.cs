using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Huach.Admin.Models
{
    /// <summary>
    /// 实体类基类
    /// </summary>
    public class ModelBase
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public int CreateBy { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public Nullable<DateTime> ModifyDate { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        public int ModifyBy { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public short Disable { get; set; }

        public enum DisableEnum
        {
            /// <summary>
            /// 正常
            /// </summary>
            Normal = 1,
            /// <summary>
            /// 禁用
            /// </summary>
            Disable = 0
        }
    }
}
