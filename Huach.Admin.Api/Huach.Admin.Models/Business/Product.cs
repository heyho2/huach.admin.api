using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Huach.Admin.Models.Basic
{
    [Table("t_product")]
    public partial class Product : ModelBase
    {
        /// <summary>
        /// 标题
        /// </summary>
        [StringLength(30)]
        public string Title { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public short Type { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 品牌
        /// </summary>
        public short Brand { get; set; }
        /// <summary>
        /// 是否发布
        /// </summary>
        public bool IsPublish { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        public long Code { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Qty { get; set; }
        /// <summary>
        ///阅读数量 
        /// </summary>
        public int ReadCount { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [Column(TypeName = "ntext")]
        public string Content { get; set; }
    }
}
