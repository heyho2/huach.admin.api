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
    /// NewsController 
    /// </summary>
    public class NewsController: BaseApiController 
    {    
		private readonly NewsService _newsService;
		public NewsController(NewsService newsService)
		{
			_newsService = newsService;
		}
		
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<int>)), HttpGet]
        public virtual IHttpActionResult Delete([FromUri]NewsDeleteRequest request)
        {
            var result = _newsService.Delete(a => a.Id == request.Id);
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
        [ResponseType(typeof(ActionResult<NewsAddResponse>)), HttpPost]
        public virtual IHttpActionResult Add(NewsAddRequest request)
        {
            var entity = new News
            {

            };
            var result = _newsService.Add(entity);
            if (result > 0)
            {
                return Succeed(new NewsAddResponse
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
        [ResponseType(typeof(ActionResult<NewsUpdateResponse>)), HttpPost]
        public virtual IHttpActionResult Update(NewsUpdateRequest request)
        {
            var entity = new News
            {
                Id = request.Id,
            };
            var result = _newsService.Update(entity);
            if (result > 0)
            {
                return Succeed(new NewsUpdateResponse
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
        [ResponseType(typeof(ActionResult<NewsFindResponse>)), HttpGet]
        public virtual IHttpActionResult Find([FromUri]NewsFindRequest request)
        {
            var result = _newsService.Find(request.Id);
            if (result == null)
            {
                return Fail("抱歉，没查到数据");
            }
            return Succeed(new NewsFindResponse
            {
                Id = result.Id
            });
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<NewsSearchResponse>)), HttpGet]
        public virtual IHttpActionResult Search([FromUri]NewsSearchRequest request)
        {
            Expression<Func<News, bool>> expression = a => true;
            var result = _newsService.LoadPaging(expression, a => new NewsSearchItem
            {

            }, request);
            return Succeed(new NewsSearchResponse
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
        public virtual IHttpActionResult Disable(NewsDisableRequest request)
        {
            var entity = new News
            {
                Id = request.Id,
            };
            var result = _newsService.Disable(request.Id);
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
    
