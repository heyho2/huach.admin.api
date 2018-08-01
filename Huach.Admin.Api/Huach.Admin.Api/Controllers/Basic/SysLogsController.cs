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
    /// SysLogsController 
    /// </summary>
    public class SysLogsController: BaseApiController 
    {    
		private readonly SysLogsService _sysLogsService;
		public SysLogsController(SysLogsService sysLogsService)
		{
			_sysLogsService = sysLogsService;
		}
		
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<int>)), HttpGet]
        public virtual IHttpActionResult Delete([FromUri]SysLogsDeleteRequest request)
        {
            var result = _sysLogsService.Delete(a => a.Id == request.Id);
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
        [ResponseType(typeof(ActionResult<SysLogsAddResponse>)), HttpPost]
        public virtual IHttpActionResult Add(SysLogsAddRequest request)
        {
            var entity = new SysLogs
            {

            };
            var result = _sysLogsService.Add(entity);
            if (result > 0)
            {
                return Succeed(new SysLogsAddResponse
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
        [ResponseType(typeof(ActionResult<SysLogsUpdateResponse>)), HttpPost]
        public virtual IHttpActionResult Update(SysLogsUpdateRequest request)
        {
            var entity = new SysLogs
            {
                Id = request.Id,
            };
            var result = _sysLogsService.Update(entity);
            if (result > 0)
            {
                return Succeed(new SysLogsUpdateResponse
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
        [ResponseType(typeof(ActionResult<SysLogsFindResponse>)), HttpGet]
        public virtual IHttpActionResult Find([FromUri]SysLogsFindRequest request)
        {
            var result = _sysLogsService.Find(request.Id);
            if (result == null)
            {
                return Fail("抱歉，没查到数据");
            }
            return Succeed(new SysLogsFindResponse
            {
                Id = result.Id
            });
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<SysLogsSearchResponse>)), HttpGet]
        public virtual IHttpActionResult Search([FromUri]SysLogsSearchRequest request)
        {
            Expression<Func<SysLogs, bool>> expression = a => true;
            var result = _sysLogsService.LoadPaging(expression, a => new SysLogsSearchItem
            {

            }, request);
            return Succeed(new SysLogsSearchResponse
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
        public virtual IHttpActionResult Disable(SysLogsDisableRequest request)
        {
            var entity = new SysLogs
            {
                Id = request.Id,
            };
            var result = _sysLogsService.Disable(request.Id);
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
    
