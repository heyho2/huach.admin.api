using Huach.Admin.ViewModels.Base;
using Huach.Admin.ViewModels.Basic;
using System.ComponentModel.DataAnnotations;
namespace Huach.Admin.ViewModels.Basic
{    
	/// <summary>
    /// 删除请求参数
    /// </summary>
    public class SysDictionaryDeleteRequest : BaseRequest
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
    public class SysDictionaryAddRequest : BaseRequest
    {

    }
    /// <summary>
    /// 更新参数类
    /// </summary>
    public class SysDictionaryUpdateRequest : BaseRequest
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
    public class SysDictionaryFindRequest : BaseRequest
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
    public class SysDictionarySearchRequest : BasePagingRequest
    {
    }
    /// <summary>
    /// 禁用请求参数
    /// </summary>
    public class SysDictionaryDisableRequest : BaseRequest
    {
        /// <summary>
        /// id 必填
        /// </summary>
        [Required]
        public int Id { get; set; }
    }
}
    
