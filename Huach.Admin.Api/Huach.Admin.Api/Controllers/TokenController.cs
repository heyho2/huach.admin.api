using Huach.Admin.Models;
using Huach.Admin.Service;
using Huach.Admin.Service.Basic;
using Huach.Admin.ViewModels;
using Huach.Admin.ViewModels.Basic;
using Huach.Framework.Encrypt;
using Huach.Framework.Helper;
using Huach.Framework.Models;
using Huach.Framework.Redis;
using System;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace Huach.Admin.Api.Controllers
{
    /// <summary>
    /// 用户登录 Token
    /// </summary>
    public class TokenController : BaseApiController
    {
        private readonly SysUserService _sysUserService;
        public TokenController(SysUserService sysUserService)
        {
            _sysUserService = sysUserService;
        }
        private static readonly string _secret;
        static TokenController()
        {
            _secret = ConfigurationManager.AppSettings[Contants.TokenSecret];
        }
        /// <summary>
        /// 获取token
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [ResponseType(typeof(ActionResult<LoginResponse>)), HttpPost]
        public IHttpActionResult Login(LoginRequest request)
        {
            var user = _sysUserService.FirstOrDefault(a => a.UserName == request.UserName && a.Disable == (short)BaseModel.DisableEnum.Normal);

            if (user == null)
            {
                return Fail("用户不存在");
            }
            if (user.Password != request.Password)
            {
                return Fail("密码错误！");
            }
            var roles = _sysUserService.GetRoles();
            var userInfo = new UserInfo
            {
                UserName = user.UserName,
                Name = user.Name,
                Avatar = user.Avatar,
                Id = user.Id,
                IsManager = user.IsManager,
                Mobile = user.Mobile,
                Roles = new int[] { 1, 2, 3, 4 },
                Expired = DateTime.Now
            };
            using (var service = new RedisStringService())
            {
                var token = MD5Encrypt.Encrypt($"{DateTime.Now.ToString("MMdd")}{userInfo.UserName}{DateTime.Now}{Util.MicroTime()}");
                service.Set(string.Format(RedisKey.AdminToken, token), userInfo);
                return Succeed(new LoginResponse
                {
                    UserName = user.UserName,
                    Token = token,
                    Id = user.Id,
                });
            }
        }
        /// <summary>
        /// 获取登陆后的用户信息
        /// </summary>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<UserInfo>)), HttpGet]
        public IHttpActionResult GetUser()
        {
            return Succeed(HttpContext.Current.GetOwinContext().Get<UserInfo>(nameof(UserInfo)));
        }
        /// <summary>
        /// 退出登陆
        /// </summary>
        /// <returns></returns>
        [ResponseType(typeof(ActionResult<string>)), HttpGet]
        public IHttpActionResult Logout()
        {
            var token = ActionContext.Request.Headers.GetValues(Contants.TokenName).FirstOrDefault();
            //清空
            HttpContext.Current.GetOwinContext().Set<UserInfo>(nameof(UserInfo), null);
            using (var service = new RedisStringService())
            {
                service.Remove(string.Format(RedisKey.AdminToken, token));
            }
            return Succeed();
        }

       
    }
}
