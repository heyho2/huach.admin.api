using Huach.Framework.Controllers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;

namespace Huach.Admin.Api.Controllers
{
    /// <summary>
    /// 用户登录 Token
    /// </summary>
    public class TokenController : BaseJwtAuthApiController
    {
        private static string _secret;
        protected override string Secret => _secret;
        protected override int ExpiredMinutes => base.ExpiredMinutes;
        static TokenController()
        {
            _secret = ConfigurationManager.AppSettings[Contants.TokenSecret];
        }
        protected override bool VerifyLogin(string userIdentification, string password, out IDictionary<string, object> payload)
        {
            //var user = _systemUserSerivce.GetAll().FirstOrDefault(a => a.UserName == userIdentification);
            if (!(userIdentification == "admin" && password == "123"))
            {
                payload = new Dictionary<string, object>();
                return false;
            }
            //if (user == null)
            //    return false;
            //if (!SzTouYun.Framework.Security.CryptoHelper.EqualsSaltMD5Str(password, user.Password))
            //    return false;
            payload = new Dictionary<string, object>()
            {
                { "UserIdentification",userIdentification},
                { "CreateTime",DateTime.Now},
            };
            return true;
        }
        /// <summary>
        /// 获取token
        /// </summary>
        /// <param name="userIdentification">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public override IHttpActionResult Login(string userIdentification, string password)
        {
            return base.Login(userIdentification, password);
        }
    }
}
