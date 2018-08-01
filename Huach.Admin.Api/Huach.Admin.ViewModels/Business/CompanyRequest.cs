using Huach.Admin.ViewModels.Base;
using Huach.Admin.ViewModels.Business;
using System.ComponentModel.DataAnnotations;
namespace Huach.Admin.ViewModels.Business
{    
	/// <summary>
    /// 删除请求参数
    /// </summary>
    public class CompanyDeleteRequest : BaseRequest
    {
        /// <summary>
        /// id 必填
        /// </summary>
        [Required]
        public int Id { get; set; }
    }
    /// <summary>
    /// 添加请求参数
    /// </summary>
    public class CompanyAddRequest : BaseRequest
    {

    }
    /// <summary>
    /// 更新参数类
    /// </summary>
    public class CompanyUpdateRequest : BaseRequest
    {
        /// <summary>
        /// id 必填
        /// </summary>
        [Required]
        public int Id { get; set; }
    }
    /// <summary>
    /// 删除请求参数
    /// </summary>
    public class CompanyFindRequest : BaseRequest
    {
        /// <summary>
        /// id 必填
        /// </summary>
        [Required]
        public int Id { get; set; }
    }
    /// <summary>
    /// 搜索请求参数
    /// </summary>
    public class CompanySearchRequest : BasePagingRequest
    {
    }
    /// <summary>
    /// 禁用请求参数
    /// </summary>
    public class CompanyDisableRequest : BaseRequest
    {
        /// <summary>
        /// id 必填
        /// </summary>
        [Required]
        public int Id { get; set; }
    }
}
    
