using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huach.Admin.Models.Business
{
    [Table("t_company")]
    public partial class Company:ModelBase
    {
        /// <summary>
        /// qq
        /// </summary>
        [StringLength(10), Column(TypeName = "varchar")]
        public string QQ { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        [StringLength(30), Column(TypeName = "varchar")]
        public string Email { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        [StringLength(200)]
        public string Address { get; set; }
        /// <summary>
        /// 地图经度
        /// </summary>
        public double Longitude { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public double Latitude { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        [StringLength(20), Column(TypeName = "varchar")]
        public string Name { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        [StringLength(20), Column(TypeName = "varchar")]
        public string Phone { get; set; }
        /// <summary>
        /// 邮编地址
        /// </summary>
        [StringLength(10), Column(TypeName = "varchar")]
        public string ZipCode { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        [StringLength(10), Column(TypeName = "varchar")]
        public string ContactPerson { get; set; }
        /// <summary>
        /// 商标
        /// </summary>
        [StringLength(200)]
        public string Logo { get; set; }
    }
}
