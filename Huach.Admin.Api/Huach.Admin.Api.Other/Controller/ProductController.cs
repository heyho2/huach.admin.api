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
    /// ProductController 
    /// </summary>
    public class ProductController: BaseApiController 
    {    
		private readonly ProductService _productService;
		public ProductController(ProductService productService)
		{
			_productService = productService;
		}
		
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<int>)), HttpGet]
        public virtual IHttpActionResult Delete([FromUri]ProductDeleteRequest request)
        {
            var result = _productService.Delete(a => a.Id == request.Id);
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
        [ResponseType(typeof(ActionResult<ProductAddResponse>)), HttpPost]
        public virtual IHttpActionResult Add(ProductAddRequest request)
        {
            var entity = new Product
            {

            };
            var result = _productService.Add(entity);
            if (result > 0)
            {
                return Succeed(new ProductAddResponse
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
        [ResponseType(typeof(ActionResult<ProductUpdateResponse>)), HttpPost]
        public virtual IHttpActionResult Update(ProductUpdateRequest request)
        {
            var entity = new Product
            {
                Id = request.Id,
            };
            var result = _productService.Update(entity);
            if (result > 0)
            {
                return Succeed(new ProductUpdateResponse
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
        [ResponseType(typeof(ActionResult<ProductFindResponse>)), HttpGet]
        public virtual IHttpActionResult Find([FromUri]ProductFindRequest request)
        {
            var result = _productService.Find(request.Id);
            if (result == null)
            {
                return Fail("抱歉，没查到数据");
            }
            return Succeed(new ProductFindResponse
            {
                Id = result.Id
            });
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<ProductSearchResponse>)), HttpGet]
        public virtual IHttpActionResult Search([FromUri]ProductSearchRequest request)
        {
            Expression<Func<Product, bool>> expression = a => true;
            var result = _productService.LoadPaging(expression, a => new ProductSearchItem
            {

            }, request);
            return Succeed(new ProductSearchResponse
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
        public virtual IHttpActionResult Disable(ProductDisableRequest request)
        {
            var entity = new Product
            {
                Id = request.Id,
            };
            var result = _productService.Disable(request.Id);
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
    
