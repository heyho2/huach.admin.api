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
    /// SysDictionaryTypeController 
    /// </summary>
    public class SysDictionaryTypeController: BaseApiController 
    {    
		private readonly SysDictionaryTypeService _sysDictionaryTypeService;
		public SysDictionaryTypeController(SysDictionaryTypeService sysDictionaryTypeService)
		{
			_sysDictionaryTypeService = sysDictionaryTypeService;
		}
		
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<int>)), HttpGet]
        public virtual IHttpActionResult Delete([FromUri]SysDictionaryTypeDeleteRequest request)
        {
            var result = _sysDictionaryTypeService.Delete(a => a.Id == request.Id);
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
        [ResponseType(typeof(ActionResult<SysDictionaryTypeAddResponse>)), HttpPost]
        public virtual IHttpActionResult Add(SysDictionaryTypeAddRequest request)
        {
            var entity = new SysDictionaryType
            {

            };
            var result = _sysDictionaryTypeService.Add(entity);
            if (result > 0)
            {
                return Succeed(new SysDictionaryTypeAddResponse
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
        [ResponseType(typeof(ActionResult<SysDictionaryTypeUpdateResponse>)), HttpPost]
        public virtual IHttpActionResult Update(SysDictionaryTypeUpdateRequest request)
        {
            var entity = new SysDictionaryType
            {
                Id = request.Id,
            };
            var result = _sysDictionaryTypeService.Update(entity);
            if (result > 0)
            {
                return Succeed(new SysDictionaryTypeUpdateResponse
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
        [ResponseType(typeof(ActionResult<SysDictionaryTypeFindResponse>)), HttpGet]
        public virtual IHttpActionResult Find([FromUri]SysDictionaryTypeFindRequest request)
        {
            var result = _sysDictionaryTypeService.Find(request.Id);
            if (result == null)
            {
                return Fail("抱歉，没查到数据");
            }
            return Succeed(new SysDictionaryTypeFindResponse
            {
                Id = result.Id
            });
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<SysDictionaryTypeSearchResponse>)), HttpGet]
        public virtual IHttpActionResult Search([FromUri]SysDictionaryTypeSearchRequest request)
        {
            Expression<Func<SysDictionaryType, bool>> expression = a => true;
            var result = _sysDictionaryTypeService.LoadPaging(expression, a => new SysDictionaryTypeSearchItem
            {

            }, request);
            return Succeed(new SysDictionaryTypeSearchResponse
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
        public virtual IHttpActionResult Disable(SysDictionaryTypeDisableRequest request)
        {
            var entity = new SysDictionaryType
            {
                Id = request.Id,
            };
            var result = _sysDictionaryTypeService.Disable(request.Id);
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
    
