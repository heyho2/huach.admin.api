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
    /// SysMenuController 
    /// </summary>
    public class SysMenuController: BaseApiController 
    {    
		private readonly SysMenuService _sysMenuService;
		public SysMenuController(SysMenuService sysMenuService)
		{
			_sysMenuService = sysMenuService;
		}
		
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<int>)), HttpGet]
        public virtual IHttpActionResult Delete([FromUri]SysMenuDeleteRequest request)
        {
            var result = _sysMenuService.Delete(a => a.Id == request.Id);
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
        [ResponseType(typeof(ActionResult<SysMenuAddResponse>)), HttpPost]
        public virtual IHttpActionResult Add(SysMenuAddRequest request)
        {
            var entity = new SysMenu
            {

            };
            var result = _sysMenuService.Add(entity);
            if (result > 0)
            {
                return Succeed(new SysMenuAddResponse
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
        [ResponseType(typeof(ActionResult<SysMenuUpdateResponse>)), HttpPost]
        public virtual IHttpActionResult Update(SysMenuUpdateRequest request)
        {
            var entity = new SysMenu
            {
                Id = request.Id,
            };
            var result = _sysMenuService.Update(entity);
            if (result > 0)
            {
                return Succeed(new SysMenuUpdateResponse
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
        [ResponseType(typeof(ActionResult<SysMenuFindResponse>)), HttpGet]
        public virtual IHttpActionResult Find([FromUri]SysMenuFindRequest request)
        {
            var result = _sysMenuService.Find(request.Id);
            if (result == null)
            {
                return Fail("抱歉，没查到数据");
            }
            return Succeed(new SysMenuFindResponse
            {
                Id = result.Id
            });
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<SysMenuSearchResponse>)), HttpGet]
        public virtual IHttpActionResult Search([FromUri]SysMenuSearchRequest request)
        {
            Expression<Func<SysMenu, bool>> expression = a => true;
            var result = _sysMenuService.LoadPaging(expression, a => new SysMenuSearchItem
            {

            }, request);
            return Succeed(new SysMenuSearchResponse
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
        public virtual IHttpActionResult Disable(SysMenuDisableRequest request)
        {
            var entity = new SysMenu
            {
                Id = request.Id,
            };
            var result = _sysMenuService.Disable(request.Id);
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
    
