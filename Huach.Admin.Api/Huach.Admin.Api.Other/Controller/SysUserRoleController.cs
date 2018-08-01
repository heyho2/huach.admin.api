using Huach.Admin.Models.Basic;
using Huach.Admin.Service.Basic;
using Huach.Admin.ViewModels.Basic;
using Huach.Framework.Models;
using System;
using System.Linq.Expressions;
using System.Web.Http;
using System.Web.Http.Description;
namespace Huach.Admin.Api.Controllers.Basic
{    
    /// <summary>
    /// SysUserRoleController 
    /// </summary>
    public class SysUserRoleController: BaseApiController 
    {    
		private readonly SysUserRoleService _sysUserRoleService;
		public SysUserRoleController(SysUserRoleService sysUserRoleService)
		{
			_sysUserRoleService = sysUserRoleService;
		}
		
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<int>)), HttpGet]
        public virtual IHttpActionResult Delete([FromUri]SysUserRoleDeleteRequest request)
        {
            var result = _sysUserRoleService.Delete(a => a.Id == request.Id);
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
        [ResponseType(typeof(ActionResult<SysUserRoleAddResponse>)), HttpPost]
        public virtual IHttpActionResult Add(SysUserRoleAddRequest request)
        {
            var entity = new SysUserRole
            {

            };
            var result = _sysUserRoleService.Add(entity);
            if (result > 0)
            {
                return Succeed(new SysUserRoleAddResponse
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
        [ResponseType(typeof(ActionResult<SysUserRoleUpdateResponse>)), HttpPost]
        public virtual IHttpActionResult Update(SysUserRoleUpdateRequest request)
        {
            var entity = new SysUserRole
            {
                Id = request.Id,
            };
            var result = _sysUserRoleService.Update(entity);
            if (result > 0)
            {
                return Succeed(new SysUserRoleUpdateResponse
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
        [ResponseType(typeof(ActionResult<SysUserRoleFindResponse>)), HttpGet]
        public virtual IHttpActionResult Find([FromUri]SysUserRoleFindRequest request)
        {
            var result = _sysUserRoleService.Find(request.Id);
            if (result == null)
            {
                return Fail("抱歉，没查到数据");
            }
            return Succeed(new SysUserRoleFindResponse
            {
                Id = result.Id
            });
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<SysUserRoleSearchResponse>)), HttpGet]
        public virtual IHttpActionResult Search([FromUri]SysUserRoleSearchRequest request)
        {
            Expression<Func<SysUserRole, bool>> expression = a => true;
            var result = _sysUserRoleService.LoadPaging(expression, a => new SysUserRoleSearchItem
            {

            }, request);
            return Succeed(new SysUserRoleSearchResponse
            {
                Count = result.Count,
                Items = result.Items,
                Total = result.Total,
            });
        }
        /// <summary>
        /// 禁用（逻辑删除）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<int>)), HttpGet]
        public virtual IHttpActionResult Disable(SysUserRoleDisableRequest request)
        {
            var entity = new SysUserRole
            {
                Id = request.Id,
            };
            var result = _sysUserRoleService.Disable(request.Id);
            if (result > 0)
            {
                return Succeed("禁用成功");
            }
            else
            {
                return Fail("禁用失败");
            }
        }
    }
}
    
