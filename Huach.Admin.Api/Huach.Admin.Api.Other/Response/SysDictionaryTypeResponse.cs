using Huach.Admin.ViewModels.Base;
using Huach.Admin.ViewModels.Basic;
using System.ComponentModel.DataAnnotations;
namespace Huach.Admin.ViewModels.Basic
{    
	/// <summary>
    /// 删除响应
    /// </summary>
    public class SysDictionaryTypeDeleteResponse : BaseResponse
    {
    }
    /// <summary>
    /// 添加响应
    /// </summary>
    public class SysDictionaryTypeAddResponse : BaseResponse
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }
    }
    /// <summary>
    /// 更新响应
    /// </summary>
    public class SysDictionaryTypeUpdateResponse : BaseResponse
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }
    }
    /// <summary>
    /// 删除响应
    /// </summary>
    public class SysDictionaryTypeFindResponse : BaseResponse
    {
        /// <summary>
        /// id 
        /// </summary>
        public int Id { get; set; }
    }
    /// <summary>
    /// 查询请求参数类
    /// </summary>
    public class SysDictionaryTypeSearchResponse : BasePagingResponse<SysDictionaryTypeSearchItem>
    {
    }
    /// <summary>
    /// 查询响应
    /// </summary>
    public class SysDictionaryTypeSearchItem : BaseItemResponse
    {
        /// <summary>
        /// id
        /// </summary>
        public object Id { get; set; }
    }
}
    
