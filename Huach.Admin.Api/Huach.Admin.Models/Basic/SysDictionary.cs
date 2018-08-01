using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Huach.Admin.Models.Basic
{
    [Table("sys_dictionary")]
    public partial class SysDictionary : ModelBase
    {
        /// <summary>
        /// 编码
        /// </summary>
        [StringLength(50), Required, Column(TypeName = "varchar")]
        public string Code { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        [StringLength(500), Required, Column(TypeName = "varchar")]
        public string Value { get; set; }
        /// <summary>
        /// 类型编码
        /// </summary>
        [StringLength(50), Required, Column(TypeName = "varchar")]
        public string DictionaryTypeCode { get; set; }
        /// <summary>
        /// 类型ID
        /// </summary>
        public int DictionaryTypeId { get; set; }
        /// <summary>
        /// 父id
        /// </summary>
        public int ParentId { get; set; }
        /// <summary>
        /// 排序 
        /// </summary>
        public int Sort { get; set; }

    }
}
