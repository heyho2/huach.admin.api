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
    /// CompanyController 
    /// </summary>
    public class CompanyController: BaseApiController 
    {    
		private readonly CompanyService _companyService;
		public CompanyController(CompanyService companyService)
		{
			_companyService = companyService;
		}
		
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<int>)), HttpGet]
        public virtual IHttpActionResult Delete([FromUri]CompanyDeleteRequest request)
        {
            var result = _companyService.Delete(a => a.Id == request.Id);
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
        [ResponseType(typeof(ActionResult<CompanyAddResponse>)), HttpPost]
        public virtual IHttpActionResult Add(CompanyAddRequest request)
        {
            var entity = new Company
            {

            };
            var result = _companyService.Add(entity);
            if (result > 0)
            {
                return Succeed(new CompanyAddResponse
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
        [ResponseType(typeof(ActionResult<CompanyUpdateResponse>)), HttpPost]
        public virtual IHttpActionResult Update(CompanyUpdateRequest request)
        {
            var entity = new Company
            {
                Id = request.Id,
            };
            var result = _companyService.Update(entity);
            if (result > 0)
            {
                return Succeed(new CompanyUpdateResponse
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
        [ResponseType(typeof(ActionResult<CompanyFindResponse>)), HttpGet]
        public virtual IHttpActionResult Find([FromUri]CompanyFindRequest request)
        {
            var result = _companyService.Find(request.Id);
            if (result == null)
            {
                return Fail("抱歉，没查到数据");
            }
            return Succeed(new CompanyFindResponse
            {
                Id = result.Id
            });
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<CompanySearchResponse>)), HttpGet]
        public virtual IHttpActionResult Search([FromUri]CompanySearchRequest request)
        {
            Expression<Func<Company, bool>> expression = a => true;
            var result = _companyService.LoadPaging(expression, a => new CompanySearchItem
            {

            }, request);
            return Succeed(new CompanySearchResponse
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
        public virtual IHttpActionResult Disable(CompanyDisableRequest request)
        {
            var entity = new Company
            {
                Id = request.Id,
            };
            var result = _companyService.Disable(request.Id);
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
    
