using Huach.Admin.Models.Basic;
using Huach.Admin.Service.Basic;
using Huach.Framework.Models;
using System;
using System.Web.Http;
using System.Web.Http.Description;

namespace Huach.Admin.Api.Controllers
{
    /// <summary>
    /// 用户
    /// </summary>
    public class SysUserController : BaseApiController
    {
        readonly SysUserService _sysUserService = null;
        public SysUserController(SysUserService sysUserService)
        {
            _sysUserService = sysUserService;
        }
        /// <summary>
        /// 获取用户
        /// </summary>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<SysUser>)), HttpGet]
        public IHttpActionResult Get(int id)
        {
            var aa = _sysUserService.Find(id);
            return Succeed(aa ?? new SysUser
            {
                Id = 1,
            });
        }
        /// <summary>
        /// 异常测试
        /// </summary>
        /// <param name="hahah"></param>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<SysUser>)), HttpGet, AllowAnonymous]
        public IHttpActionResult Error2(string hahah)
        {
            throw new Exception("麻痹，异常了");
        }
    }
}
