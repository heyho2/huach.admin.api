using Huach.Admin.ViewModels.Base;
using Huach.Admin.ViewModels.Business;
using System.ComponentModel.DataAnnotations;
namespace Huach.Admin.ViewModels.Business
{    
	/// <summary>
    /// 删除响应
    /// </summary>
    public class AdvertisingImageDeleteResponse : BaseResponse
    {
    }
    /// <summary>
    /// 添加响应
    /// </summary>
    public class AdvertisingImageAddResponse : BaseResponse
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }
    }
    /// <summary>
    /// 更新响应
    /// </summary>
    public class AdvertisingImageUpdateResponse : BaseResponse
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }
    }
    /// <summary>
    /// 删除响应
    /// </summary>
    public class AdvertisingImageFindResponse : BaseResponse
    {
        /// <summary>
        /// id 
        /// </summary>
        public int Id { get; set; }
    }
    /// <summary>
    /// 查询请求参数类
    /// </summary>
    public class AdvertisingImageSearchResponse : BasePagingResponse<AdvertisingImageSearchItem>
    {
    }
    /// <summary>
    /// 查询响应
    /// </summary>
    public class AdvertisingImageSearchItem : BaseItemResponse
    {
        /// <summary>
        /// id
        /// </summary>
        public object Id { get; set; }
    }
}
    
