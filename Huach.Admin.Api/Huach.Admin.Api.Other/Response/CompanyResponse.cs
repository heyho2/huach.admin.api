using Huach.Admin.ViewModels.Base;
using Huach.Admin.ViewModels.Business;
using System.ComponentModel.DataAnnotations;
namespace Huach.Admin.ViewModels.Business
{    
	/// <summary>
    /// 删除响应
    /// </summary>
    public class CompanyDeleteResponse : BaseResponse
    {
    }
    /// <summary>
    /// 添加响应
    /// </summary>
    public class CompanyAddResponse : BaseResponse
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }
    }
    /// <summary>
    /// 更新响应
    /// </summary>
    public class CompanyUpdateResponse : BaseResponse
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }
    }
    /// <summary>
    /// 删除响应
    /// </summary>
    public class CompanyFindResponse : BaseResponse
    {
        /// <summary>
        /// id 
        /// </summary>
        public int Id { get; set; }
    }
    /// <summary>
    /// 查询请求参数类
    /// </summary>
    public class CompanySearchResponse : BasePagingResponse<CompanySearchItem>
    {
    }
    /// <summary>
    /// 查询响应
    /// </summary>
    public class CompanySearchItem : BaseItemResponse
    {
        /// <summary>
        /// id
        /// </summary>
        public object Id { get; set; }
    }
}
    
