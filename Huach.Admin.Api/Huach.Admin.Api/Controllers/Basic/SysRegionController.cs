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
    /// SysRegionController 
    /// </summary>
    public class SysRegionController: BaseApiController 
    {    
		private readonly SysRegionService _sysRegionService;
		public SysRegionController(SysRegionService sysRegionService)
		{
			_sysRegionService = sysRegionService;
		}
		
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<int>)), HttpGet]
        public virtual IHttpActionResult Delete([FromUri]SysRegionDeleteRequest request)
        {
            var result = _sysRegionService.Delete(a => a.Id == request.Id);
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
        [ResponseType(typeof(ActionResult<SysRegionAddResponse>)), HttpPost]
        public virtual IHttpActionResult Add(SysRegionAddRequest request)
        {
            var entity = new SysRegion
            {

            };
            var result = _sysRegionService.Add(entity);
            if (result > 0)
            {
                return Succeed(new SysRegionAddResponse
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
        [ResponseType(typeof(ActionResult<SysRegionUpdateResponse>)), HttpPost]
        public virtual IHttpActionResult Update(SysRegionUpdateRequest request)
        {
            var entity = new SysRegion
            {
                Id = request.Id,
            };
            var result = _sysRegionService.Update(entity);
            if (result > 0)
            {
                return Succeed(new SysRegionUpdateResponse
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
        [ResponseType(typeof(ActionResult<SysRegionFindResponse>)), HttpGet]
        public virtual IHttpActionResult Find([FromUri]SysRegionFindRequest request)
        {
            var result = _sysRegionService.Find(request.Id);
            if (result == null)
            {
                return Fail("抱歉，没查到数据");
            }
            return Succeed(new SysRegionFindResponse
            {
                Id = result.Id
            });
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<SysRegionSearchResponse>)), HttpGet]
        public virtual IHttpActionResult Search([FromUri]SysRegionSearchRequest request)
        {
            Expression<Func<SysRegion, bool>> expression = a => true;
            var result = _sysRegionService.LoadPaging(expression, a => new SysRegionSearchItem
            {

            }, request);
            return Succeed(new SysRegionSearchResponse
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
        public virtual IHttpActionResult Disable(SysRegionDisableRequest request)
        {
            var entity = new SysRegion
            {
                Id = request.Id,
            };
            var result = _sysRegionService.Disable(request.Id);
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
    
