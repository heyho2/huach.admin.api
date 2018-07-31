using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Huach.Admin.Models.Basic
{
    [Table("t_product_attr")]
    public partial class ProductAttr : ModelBase
    {
        /// <summary>
        /// 属性名称
        /// </summary>
        [StringLength(30)]
        public string Name { get; set; }
        /// <summary>
        /// 属性值
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 产品Id
        /// </summary>
        public string ProductTypeId { get; set; }
    }
}
