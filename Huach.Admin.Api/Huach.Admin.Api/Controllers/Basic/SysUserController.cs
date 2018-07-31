using Huach.Admin.Models.Basic;
using Huach.Admin.Service.Basic;
using Huach.Admin.ViewModels.Base;
using Huach.Framework.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Http;
using System.Web.Http.Description;
namespace Huach.Admin.Api.Controllers.Basic
{
    /// <summary>
    /// SysUserController 
    /// </summary>
    public class SysUserController : BaseApiController
    {
        private readonly SysUserService _sysUserService;
        public SysUserController(SysUserService sysUserService)
        {
            _sysUserService = sysUserService;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<int>)), HttpGet]
        public virtual IHttpActionResult Delete([FromUri]SysUserDeleteRequest request)
        {
            var result = _sysUserService.Delete(a => a.Id == request.Id);
            if (result > 0)
            {
                return Succeed(result, "删除成功");
            }
            else
            {
                return Fail("删除失败");
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<SysUserAddResponse>)), HttpPost]
        public virtual IHttpActionResult Add(SysUserAddRequest request)
        {
            var entity = new SysUser
            {

            };
            var result = _sysUserService.Add(entity);
            if (result > 0)
            {
                return Succeed(new SysUserAddResponse
                {
                    Id = entity.Id
                }, "新增成功");
            }
            else
            {
                return Fail("新增失败");
            }
        }
        /// <summary>
        /// 修改（注意：没有修改的也要将原来的数据传回）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<SysUserUpdateResponse>)), HttpPost]
        public virtual IHttpActionResult Update(SysUserUpdateRequest request)
        {
            var entity = new SysUser
            {
                Id = request.Id,
            };
            var result = _sysUserService.Update(entity);
            if (result > 0)
            {
                return Succeed(new SysUserUpdateResponse
                {
                    Id = entity.Id
                }, "新增成功");
            }
            else
            {
                return Fail("新增失败");
            }
        }
        /// <summary>
        /// 根据id查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<SysUserFindResponse>)), HttpGet]
        public virtual IHttpActionResult Find([FromUri]SysUserFindRequest request)
        {
            var result = _sysUserService.Find(request.Id);
            if (result == null)
            {
                return Fail("抱歉，没查到数据");
            }
            return Succeed(new SysUserFindResponse
            {
                Id = result.Id
            });
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<SysUserSearchResponse>)), HttpGet]
        public virtual IHttpActionResult Search([FromUri]SysUserSearchRequest request)
        {
            Expression<Func<SysUser, bool>> expression = a => true;
            var result = _sysUserService.LoadPaging(expression, a => new SysUserSearchItem
            {

            }, request);
            return Succeed(new SysUserSearchResponse
            {
                Count = result.Count,
                Items = result.Items,
                Total = result.Total,
            });
        }


    }



    /// <summary>
    /// 删除请求参数
    /// </summary>
    public class SysUserDeleteRequest : BaseRequest
    {
        /// <summary>
        /// id 必填
        /// </summary>
        [Required]
        public int Id { get; set; }
    }
    /// <summary>
    /// 删除响应
    /// </summary>
    public class SysUserDeleteResponse : BaseResponse
    {
    }
    /// <summary>
    /// 添加请求参数
    /// </summary>
    public class SysUserAddRequest : BaseRequest
    {

    }
    /// <summary>
    /// 添加响应
    /// </summary>
    public class SysUserAddResponse : BaseResponse
    {
        public int Id { get; set; }
    }
    public class SysUserUpdateRequest : BaseRequest
    {
        /// <summary>
        /// id 必填
        /// </summary>
        [Required]
        public int Id { get; set; }
    }

    public class SysUserUpdateResponse : BaseResponse
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }
    }
    /// <summary>
    /// 删除请求参数
    /// </summary>
    public class SysUserFindRequest : BaseRequest
    {
        /// <summary>
        /// id 必填
        /// </summary>
        [Required]
        public int Id { get; set; }
    }
    /// <summary>
    /// 删除响应
    /// </summary>
    public class SysUserFindResponse : BaseResponse
    {
        /// <summary>
        /// id 
        /// </summary>
        public int Id { get; set; }
    }
    /// <summary>
    /// 搜索请求参数
    /// </summary>
    public class SysUserSearchRequest : BasePagingRequest
    {
    }
    /// <summary>
    /// 查询请求参数类
    /// </summary>
    public class SysUserSearchResponse : BasePagingResponse<SysUserSearchItem>
    {
    }
    /// <summary>
    /// 查询响应
    /// </summary>
    public class SysUserSearchItem : BaseItemResponse
    {
        /// <summary>
        /// id
        /// </summary>
        public object Id { get; set; }
    }
}

