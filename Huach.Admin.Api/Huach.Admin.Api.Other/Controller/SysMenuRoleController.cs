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
    /// SysMenuRoleController 
    /// </summary>
    public class SysMenuRoleController: BaseApiController 
    {    
		private readonly SysMenuRoleService _sysMenuRoleService;
		public SysMenuRoleController(SysMenuRoleService sysMenuRoleService)
		{
			_sysMenuRoleService = sysMenuRoleService;
		}
		
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<int>)), HttpGet]
        public virtual IHttpActionResult Delete([FromUri]SysMenuRoleDeleteRequest request)
        {
            var result = _sysMenuRoleService.Delete(a => a.Id == request.Id);
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
        [ResponseType(typeof(ActionResult<SysMenuRoleAddResponse>)), HttpPost]
        public virtual IHttpActionResult Add(SysMenuRoleAddRequest request)
        {
            var entity = new SysMenuRole
            {

            };
            var result = _sysMenuRoleService.Add(entity);
            if (result > 0)
            {
                return Succeed(new SysMenuRoleAddResponse
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
        [ResponseType(typeof(ActionResult<SysMenuRoleUpdateResponse>)), HttpPost]
        public virtual IHttpActionResult Update(SysMenuRoleUpdateRequest request)
        {
            var entity = new SysMenuRole
            {
                Id = request.Id,
            };
            var result = _sysMenuRoleService.Update(entity);
            if (result > 0)
            {
                return Succeed(new SysMenuRoleUpdateResponse
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
        [ResponseType(typeof(ActionResult<SysMenuRoleFindResponse>)), HttpGet]
        public virtual IHttpActionResult Find([FromUri]SysMenuRoleFindRequest request)
        {
            var result = _sysMenuRoleService.Find(request.Id);
            if (result == null)
            {
                return Fail("抱歉，没查到数据");
            }
            return Succeed(new SysMenuRoleFindResponse
            {
                Id = result.Id
            });
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<SysMenuRoleSearchResponse>)), HttpGet]
        public virtual IHttpActionResult Search([FromUri]SysMenuRoleSearchRequest request)
        {
            Expression<Func<SysMenuRole, bool>> expression = a => true;
            var result = _sysMenuRoleService.LoadPaging(expression, a => new SysMenuRoleSearchItem
            {

            }, request);
            return Succeed(new SysMenuRoleSearchResponse
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
        public virtual IHttpActionResult Disable(SysMenuRoleDisableRequest request)
        {
            var entity = new SysMenuRole
            {
                Id = request.Id,
            };
            var result = _sysMenuRoleService.Disable(request.Id);
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
    
