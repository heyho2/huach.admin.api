using Huach.Admin.Service;
using Huach.Admin.ViewModels;
using Huach.Framework.Models;
using Huach.Framework.Redis;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;

namespace Huach.Admin.Api.Filters
{
    public class TokenAuthFilterAttribute : BaseAuthFilterAttribute
    {
        private static readonly string _secret;

        /// <summary>
        /// 设置tokenName
        /// </summary>
        protected string TokenName => Contants.TokenName;
        static TokenAuthFilterAttribute()
        {
            _secret = ConfigurationManager.AppSettings[Contants.TokenSecret];
        }
        protected virtual string GetToken(HttpActionContext actionContext)
        {
            return actionContext.Request.Headers.GetValues(TokenName).FirstOrDefault();
        }
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (IsAllowAnonymous(actionContext))
            {
                return;
            }
            var token = GetToken(actionContext);
            if (string.IsNullOrWhiteSpace(token))
            {
                HandleUnauthenticatedRequest(actionContext, "Token为空。");
            }
            using (var service = new RedisStringService())
            {
                var userInfo = service.Get<UserInfo>(string.Format(RedisKey.AdminToken, token));
                if (userInfo == null)
                {
                    HandleUnauthenticatedRequest(actionContext, "token无效。");
                }
                base.OnAuthorization(actionContext);
            }
        }
        protected bool IsAuthenticated(UserInfo userInfo)
        {
            if (HttpContext.Current.GetOwinContext().Get<UserInfo>(nameof(UserInfo)) == null)
            {
                HttpContext.Current.GetOwinContext().Set(nameof(UserInfo), userInfo);
            }
            //if (user == null)
            //    return false;
            //TODO 从缓存中获取用户信息
            return true;
        }
    }
}

