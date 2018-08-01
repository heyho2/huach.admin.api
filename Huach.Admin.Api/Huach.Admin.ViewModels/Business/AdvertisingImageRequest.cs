using Huach.Admin.ViewModels.Base;
using Huach.Admin.ViewModels.Business;
using System.ComponentModel.DataAnnotations;
namespace Huach.Admin.ViewModels.Business
{    
	/// <summary>
    /// 删除请求参数
    /// </summary>
    public class AdvertisingImageDeleteRequest : BaseRequest
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
    public class AdvertisingImageAddRequest : BaseRequest
    {

    }
    /// <summary>
    /// 更新参数类
    /// </summary>
    public class AdvertisingImageUpdateRequest : BaseRequest
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
    public class AdvertisingImageFindRequest : BaseRequest
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
    public class AdvertisingImageSearchRequest : BasePagingRequest
    {
    }
    /// <summary>
    /// 禁用请求参数
    /// </summary>
    public class AdvertisingImageDisableRequest : BaseRequest
    {
        /// <summary>
        /// id 必填
        /// </summary>
        [Required]
        public int Id { get; set; }
    }
}
    
