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
    /// ProductTypeController 
    /// </summary>
    public class ProductTypeController: BaseApiController 
    {    
		private readonly ProductTypeService _productTypeService;
		public ProductTypeController(ProductTypeService productTypeService)
		{
			_productTypeService = productTypeService;
		}
		
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<int>)), HttpGet]
        public virtual IHttpActionResult Delete([FromUri]ProductTypeDeleteRequest request)
        {
            var result = _productTypeService.Delete(a => a.Id == request.Id);
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
        [ResponseType(typeof(ActionResult<ProductTypeAddResponse>)), HttpPost]
        public virtual IHttpActionResult Add(ProductTypeAddRequest request)
        {
            var entity = new ProductType
            {

            };
            var result = _productTypeService.Add(entity);
            if (result > 0)
            {
                return Succeed(new ProductTypeAddResponse
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
        [ResponseType(typeof(ActionResult<ProductTypeUpdateResponse>)), HttpPost]
        public virtual IHttpActionResult Update(ProductTypeUpdateRequest request)
        {
            var entity = new ProductType
            {
                Id = request.Id,
            };
            var result = _productTypeService.Update(entity);
            if (result > 0)
            {
                return Succeed(new ProductTypeUpdateResponse
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
        [ResponseType(typeof(ActionResult<ProductTypeFindResponse>)), HttpGet]
        public virtual IHttpActionResult Find([FromUri]ProductTypeFindRequest request)
        {
            var result = _productTypeService.Find(request.Id);
            if (result == null)
            {
                return Fail("抱歉，没查到数据");
            }
            return Succeed(new ProductTypeFindResponse
            {
                Id = result.Id
            });
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<ProductTypeSearchResponse>)), HttpGet]
        public virtual IHttpActionResult Search([FromUri]ProductTypeSearchRequest request)
        {
            Expression<Func<ProductType, bool>> expression = a => true;
            var result = _productTypeService.LoadPaging(expression, a => new ProductTypeSearchItem
            {

            }, request);
            return Succeed(new ProductTypeSearchResponse
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
        public virtual IHttpActionResult Disable(ProductTypeDisableRequest request)
        {
            var entity = new ProductType
            {
                Id = request.Id,
            };
            var result = _productTypeService.Disable(request.Id);
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
    
