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
    /// SysUserController 
    /// </summary>
    public class SysUserController : BaseApiController
    {
        private readonly SysUserService _sysUserService;
        public SysUserController(SysUserService sysUserService)
        {
            _sysUserService = sysUserService;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<int>)), HttpGet]
        public virtual IHttpActionResult Delete([FromUri]SysUserDeleteRequest request)
        {
            var result = _sysUserService.Delete(a => a.Id == request.Id);
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
        [ResponseType(typeof(ActionResult<SysUserAddResponse>)), HttpPost]
        public virtual IHttpActionResult Add(SysUserAddRequest request)
        {
            var entity = new SysUser
            {

            };
            var result = _sysUserService.Add(entity);
            if (result > 0)
            {
                return Succeed(new SysUserAddResponse
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
        [ResponseType(typeof(ActionResult<SysUserUpdateResponse>)), HttpPost]
        public virtual IHttpActionResult Update(SysUserUpdateRequest request)
        {
            var entity = new SysUser
            {
                Id = request.Id,
            };
            var result = _sysUserService.Update(entity);
            if (result > 0)
            {
                return Succeed(new SysUserUpdateResponse
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
        [ResponseType(typeof(ActionResult<SysUserFindResponse>)), HttpGet]
        public virtual IHttpActionResult Find([FromUri]SysUserFindRequest request)
        {
            var result = _sysUserService.Find(request.Id);
            if (result == null)
            {
                return Fail("抱歉，没查到数据");
            }
            return Succeed(new SysUserFindResponse
            {
                Id = result.Id
            });
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<SysUserSearchResponse>)), HttpGet]
        public virtual IHttpActionResult Search([FromUri]SysUserSearchRequest request)
        {
            Expression<Func<SysUser, bool>> expression = a => true;
            var result = _sysUserService.LoadPaging(expression, a => new SysUserSearchItem
            {

            }, request);
            return Succeed(new SysUserSearchResponse
            {
                Count = result.Count,
                Items = result.Items,
                Total = result.Total,
            });
        }
        /// <summary>
        /// ceshi
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<int>)), HttpPost]
        public IHttpActionResult UpdateName(int id, string name)
        {
            _sysUserService.UpdateUser(id);
            return Succeed();
        }
        /// <summary>
        /// 禁用（逻辑删除）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<int>)), HttpGet]
        public virtual IHttpActionResult Disable(SysUserDisableRequest request)
        {
            var entity = new SysUser
            {
                Id = request.Id,
            };
            var result = _sysUserService.Disable(request.Id);
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

