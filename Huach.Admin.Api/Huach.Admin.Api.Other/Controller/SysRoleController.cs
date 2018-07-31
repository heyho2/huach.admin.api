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
    /// SysRoleController 
    /// </summary>
    public class SysRoleController: BaseApiController 
    {    
		private readonly SysRoleService _sysRoleService;
		public SysRoleController(SysRoleService sysRoleService)
		{
			_sysRoleService = sysRoleService;
		}
		
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<int>)), HttpGet]
        public virtual IHttpActionResult Delete([FromUri]SysRoleDeleteRequest request)
        {
            var result = _sysRoleService.Delete(a => a.Id == request.Id);
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
        [ResponseType(typeof(ActionResult<SysRoleAddResponse>)), HttpPost]
        public virtual IHttpActionResult Add(SysRoleAddRequest request)
        {
            var entity = new SysRole
            {

            };
            var result = _sysRoleService.Add(entity);
            if (result > 0)
            {
                return Succeed(new SysRoleAddResponse
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
        [ResponseType(typeof(ActionResult<SysRoleUpdateResponse>)), HttpPost]
        public virtual IHttpActionResult Update(SysRoleUpdateRequest request)
        {
            var entity = new SysRole
            {
                Id = request.Id,
            };
            var result = _sysRoleService.Update(entity);
            if (result > 0)
            {
                return Succeed(new SysRoleUpdateResponse
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
        [ResponseType(typeof(ActionResult<SysRoleFindResponse>)), HttpGet]
        public virtual IHttpActionResult Find([FromUri]SysRoleFindRequest request)
        {
            var result = _sysRoleService.Find(request.Id);
            if (result == null)
            {
                return Fail("抱歉，没查到数据");
            }
            return Succeed(new SysRoleFindResponse
            {
                Id = result.Id
            });
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<SysRoleSearchResponse>)), HttpGet]
        public virtual IHttpActionResult Search([FromUri]SysRoleSearchRequest request)
        {
            Expression<Func<SysRole, bool>> expression = a => true;
            var result = _sysRoleService.LoadPaging(expression, a => new SysRoleSearchItem
            {

            }, request);
            return Succeed(new SysRoleSearchResponse
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
        public virtual IHttpActionResult Disable(SysRoleDisableRequest request)
        {
            var entity = new SysRole
            {
                Id = request.Id,
            };
            var result = _sysRoleService.Disable(request.Id);
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
    
