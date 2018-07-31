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
    /// SysDictionaryController 
    /// </summary>
    public class SysDictionaryController: BaseApiController 
    {    
		private readonly SysDictionaryService _sysDictionaryService;
		public SysDictionaryController(SysDictionaryService sysDictionaryService)
		{
			_sysDictionaryService = sysDictionaryService;
		}
		
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<int>)), HttpGet]
        public virtual IHttpActionResult Delete([FromUri]SysDictionaryDeleteRequest request)
        {
            var result = _sysDictionaryService.Delete(a => a.Id == request.Id);
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
        [ResponseType(typeof(ActionResult<SysDictionaryAddResponse>)), HttpPost]
        public virtual IHttpActionResult Add(SysDictionaryAddRequest request)
        {
            var entity = new SysDictionary
            {

            };
            var result = _sysDictionaryService.Add(entity);
            if (result > 0)
            {
                return Succeed(new SysDictionaryAddResponse
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
        [ResponseType(typeof(ActionResult<SysDictionaryUpdateResponse>)), HttpPost]
        public virtual IHttpActionResult Update(SysDictionaryUpdateRequest request)
        {
            var entity = new SysDictionary
            {
                Id = request.Id,
            };
            var result = _sysDictionaryService.Update(entity);
            if (result > 0)
            {
                return Succeed(new SysDictionaryUpdateResponse
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
        [ResponseType(typeof(ActionResult<SysDictionaryFindResponse>)), HttpGet]
        public virtual IHttpActionResult Find([FromUri]SysDictionaryFindRequest request)
        {
            var result = _sysDictionaryService.Find(request.Id);
            if (result == null)
            {
                return Fail("抱歉，没查到数据");
            }
            return Succeed(new SysDictionaryFindResponse
            {
                Id = result.Id
            });
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<SysDictionarySearchResponse>)), HttpGet]
        public virtual IHttpActionResult Search([FromUri]SysDictionarySearchRequest request)
        {
            Expression<Func<SysDictionary, bool>> expression = a => true;
            var result = _sysDictionaryService.LoadPaging(expression, a => new SysDictionarySearchItem
            {

            }, request);
            return Succeed(new SysDictionarySearchResponse
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
        public virtual IHttpActionResult Disable(SysDictionaryDisableRequest request)
        {
            var entity = new SysDictionary
            {
                Id = request.Id,
            };
            var result = _sysDictionaryService.Disable(request.Id);
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
    
