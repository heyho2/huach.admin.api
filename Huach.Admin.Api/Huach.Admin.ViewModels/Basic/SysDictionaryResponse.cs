using Huach.Admin.ViewModels.Base;
using Huach.Admin.ViewModels.Basic;
using System.ComponentModel.DataAnnotations;
namespace Huach.Admin.ViewModels.Basic
{    
	/// <summary>
    /// 删除响应
    /// </summary>
    public class SysDictionaryDeleteResponse : BaseResponse
    {
    }
    /// <summary>
    /// 添加响应
    /// </summary>
    public class SysDictionaryAddResponse : BaseResponse
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }
    }
    /// <summary>
    /// 更新响应
    /// </summary>
    public class SysDictionaryUpdateResponse : BaseResponse
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }
    }
    /// <summary>
    /// 删除响应
    /// </summary>
    public class SysDictionaryFindResponse : BaseResponse
    {
        /// <summary>
        /// id 
        /// </summary>
        public int Id { get; set; }
    }
    /// <summary>
    /// 查询请求参数类
    /// </summary>
    public class SysDictionarySearchResponse : BasePagingResponse<SysDictionarySearchItem>
    {
    }
    /// <summary>
    /// 查询响应
    /// </summary>
    public class SysDictionarySearchItem : BaseItemResponse
    {
        /// <summary>
        /// id
        /// </summary>
        public object Id { get; set; }
    }
}
    
