using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Huach.Admin.Models.Basic
{
    [Table("t_product_type")]
    public partial class ProductType : ModelBase
    {
        /// <summary>
        /// 属性名称
        /// </summary>
        [StringLength(30)]
        public string Code { get; set; }
        /// <summary>
        /// 属性值
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 产品Id
        /// </summary>
        public string ProductId { get; set; }
    }
}
