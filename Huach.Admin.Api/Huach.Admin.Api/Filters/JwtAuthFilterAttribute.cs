using Huach.Admin.ViewModels;
using Huach.Framework.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Huach.Framework.Extend;

namespace Huach.Admin.Api.Filters
{
    public class JwtAuthFilterAttribute : BaseJwtAuthFilterAttribute
    {
        private static string _secret;

        /// <summary>
        /// 设置Token密钥
        /// </summary>
        protected override string Secret => _secret;
        /// <summary>
        /// 设置tokenName
        /// </summary>
        protected override string JwtTokenKeyName => Contants.TokenName;
        static JwtAuthFilterAttribute()
        {
            _secret = ConfigurationManager.AppSettings[Contants.TokenSecret];
        }
        protected override string GetUserIdentification(IDictionary<string, object> payload)
        {
            if (payload?.Count > 0 && payload.ContainsKey("userName"))
            {
                return payload["userName"]?.ToString();
            }
            return null;
        }
        protected override bool IsAuthenticated(string userName, IDictionary<string, object> jwtPayload)
        {
            if (HttpContext.Current.GetOwinContext().Get<UserInfo>(nameof(UserInfo)) == null)
            {
                try
                {
                    var user = new UserInfo
                    {
                        UserName = userName,
                        Name = (string)jwtPayload.GetValue("Name"),
                        Mobile = (string)jwtPayload.GetValue("Mobile"),
                        IsManager = (bool)(jwtPayload.GetValue("IsManager") ?? false),
                        Roles = jwtPayload.GetValue("Roles") == null ? new int[0] : ((string)jwtPayload.GetValue("Roles")).Split(',').Select(a => Convert.ToInt32(a)).ToArray(),
                    };
                    HttpContext.Current.GetOwinContext().Set(nameof(UserInfo), user);
                }
                catch (Exception)
                {
                    return false;
                }
            }
            //if (user == null)
            //    return false;
            //TODO 从缓存中获取用户信息
            return true;
        }
    }
}

