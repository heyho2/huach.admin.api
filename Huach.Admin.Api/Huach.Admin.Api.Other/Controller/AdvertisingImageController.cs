using Huach.Admin.Models.Business;
using Huach.Admin.Service.Business;
using Huach.Admin.ViewModels.Business;
using Huach.Framework.Models;
using System;
using System.Linq.Expressions;
using System.Web.Http;
using System.Web.Http.Description;
namespace Huach.Admin.Api.Controllers.Business
{    
    /// <summary>
    /// AdvertisingImageController 
    /// </summary>
    public class AdvertisingImageController: BaseApiController 
    {    
		private readonly AdvertisingImageService _advertisingImageService;
		public AdvertisingImageController(AdvertisingImageService advertisingImageService)
		{
			_advertisingImageService = advertisingImageService;
		}
		
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<int>)), HttpGet]
        public virtual IHttpActionResult Delete([FromUri]AdvertisingImageDeleteRequest request)
        {
            var result = _advertisingImageService.Delete(a => a.Id == request.Id);
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
        [ResponseType(typeof(ActionResult<AdvertisingImageAddResponse>)), HttpPost]
        public virtual IHttpActionResult Add(AdvertisingImageAddRequest request)
        {
            var entity = new AdvertisingImage
            {

            };
            var result = _advertisingImageService.Add(entity);
            if (result > 0)
            {
                return Succeed(new AdvertisingImageAddResponse
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
        [ResponseType(typeof(ActionResult<AdvertisingImageUpdateResponse>)), HttpPost]
        public virtual IHttpActionResult Update(AdvertisingImageUpdateRequest request)
        {
            var entity = new AdvertisingImage
            {
                Id = request.Id,
            };
            var result = _advertisingImageService.Update(entity);
            if (result > 0)
            {
                return Succeed(new AdvertisingImageUpdateResponse
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
        [ResponseType(typeof(ActionResult<AdvertisingImageFindResponse>)), HttpGet]
        public virtual IHttpActionResult Find([FromUri]AdvertisingImageFindRequest request)
        {
            var result = _advertisingImageService.Find(request.Id);
            if (result == null)
            {
                return Fail("抱歉，没查到数据");
            }
            return Succeed(new AdvertisingImageFindResponse
            {
                Id = result.Id
            });
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<AdvertisingImageSearchResponse>)), HttpGet]
        public virtual IHttpActionResult Search([FromUri]AdvertisingImageSearchRequest request)
        {
            Expression<Func<AdvertisingImage, bool>> expression = a => true;
            var result = _advertisingImageService.LoadPaging(expression, a => new AdvertisingImageSearchItem
            {

            }, request);
            return Succeed(new AdvertisingImageSearchResponse
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
        public virtual IHttpActionResult Disable(AdvertisingImageDisableRequest request)
        {
            var entity = new AdvertisingImage
            {
                Id = request.Id,
            };
            var result = _advertisingImageService.Disable(request.Id);
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
    
