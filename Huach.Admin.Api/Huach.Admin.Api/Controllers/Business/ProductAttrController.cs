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
    /// ProductAttrController 
    /// </summary>
    public class ProductAttrController: BaseApiController 
    {    
		private readonly ProductAttrService _productAttrService;
		public ProductAttrController(ProductAttrService productAttrService)
		{
			_productAttrService = productAttrService;
		}
		
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<int>)), HttpGet]
        public virtual IHttpActionResult Delete([FromUri]ProductAttrDeleteRequest request)
        {
            var result = _productAttrService.Delete(a => a.Id == request.Id);
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
        [ResponseType(typeof(ActionResult<ProductAttrAddResponse>)), HttpPost]
        public virtual IHttpActionResult Add(ProductAttrAddRequest request)
        {
            var entity = new ProductAttr
            {

            };
            var result = _productAttrService.Add(entity);
            if (result > 0)
            {
                return Succeed(new ProductAttrAddResponse
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
        [ResponseType(typeof(ActionResult<ProductAttrUpdateResponse>)), HttpPost]
        public virtual IHttpActionResult Update(ProductAttrUpdateRequest request)
        {
            var entity = new ProductAttr
            {
                Id = request.Id,
            };
            var result = _productAttrService.Update(entity);
            if (result > 0)
            {
                return Succeed(new ProductAttrUpdateResponse
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
        [ResponseType(typeof(ActionResult<ProductAttrFindResponse>)), HttpGet]
        public virtual IHttpActionResult Find([FromUri]ProductAttrFindRequest request)
        {
            var result = _productAttrService.Find(request.Id);
            if (result == null)
            {
                return Fail("抱歉，没查到数据");
            }
            return Succeed(new ProductAttrFindResponse
            {
                Id = result.Id
            });
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<ProductAttrSearchResponse>)), HttpGet]
        public virtual IHttpActionResult Search([FromUri]ProductAttrSearchRequest request)
        {
            Expression<Func<ProductAttr, bool>> expression = a => true;
            var result = _productAttrService.LoadPaging(expression, a => new ProductAttrSearchItem
            {

            }, request);
            return Succeed(new ProductAttrSearchResponse
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
        public virtual IHttpActionResult Disable(ProductAttrDisableRequest request)
        {
            var entity = new ProductAttr
            {
                Id = request.Id,
            };
            var result = _productAttrService.Disable(request.Id);
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
    
