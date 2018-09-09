using Huach.Admin.Service.Basic;
using Huach.Admin.ViewModels.Basic;
using Huach.Framework.Controllers;
using Huach.Framework.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;
using System.Web.Http.Description;
using Huach.Framework.Jwt;
using Huach.Admin.ViewModels;
using System.Web;
using Huach.Admin.Models;

namespace Huach.Admin.Api.Controllers
{
    /// <summary>
    /// 用户登录 Token
    /// </summary>
    public class TokenController : BaseJwtAuthApiController
    {
        private readonly SysUserService _sysUserService;
        public TokenController(SysUserService sysUserService)
        {
            _sysUserService = sysUserService;
        }
        private static string _secret;
        protected override string Secret => _secret;
        protected override int ExpiredMinutes => base.ExpiredMinutes;
        static TokenController()
        {
            _secret = ConfigurationManager.AppSettings[Contants.TokenSecret];
        }
        protected override bool VerifyLogin(string userName, string password, out IDictionary<string, object> payload)
        {
            payload = new Dictionary<string, object>();
            var user = _sysUserService.FirstOrDefault(a => a.UserName == userName && a.Disable == (short)ModelBase.DisableEnum.Normal);

            if (user == null)
                return false;
            if (user.Password != password)
                return false;
            var roles = _sysUserService.GetRoles();
            if (roles == null || roles.Length == 0)
            {
                roles = new int[1] { 0 };
            }
            payload = new Dictionary<string, object>()
            {
                { "UserName",userName},
                { "LoginTime",DateTime.Now},
                { "Name",user.Name},
                { "Mobile",user.Mobile},
                { "IsManager",user.IsManager},
                { "Roles",string.Join(",",roles)},
            };
            return true;
        }
        /// <summary>
        /// 获取token
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [ResponseType(typeof(ActionResult<string>)), HttpPost]
        public IHttpActionResult Login(LoginRequest request)
        {
            return base.Login(request.UserName, request.Password);
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
            //清空
            HttpContext.Current.GetOwinContext().Set<UserInfo>(nameof(UserInfo), null);
            return base.Logout(new Dictionary<string, object>()
            {
                { "LoginTime",DateTime.Now},
            });
        }
    }
}
