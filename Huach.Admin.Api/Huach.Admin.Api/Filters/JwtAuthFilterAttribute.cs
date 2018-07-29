using Huach.Admin.ViewModels;
using Huach.Framework.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

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
            if (payload?.Count > 0 && payload.ContainsKey("UserIdentification"))
            {
                return payload["UserIdentification"]?.ToString();
            }
            return null;
        }
        protected override bool IsAuthenticated(string userIdentification, IDictionary<string, object> jwtPayload)
        {
            //SystemUserSerivce systemUserSerivce = ServiceProvider.Current.GetService<SystemUserSerivce>(); 

            //SystemUserInfo user = systemUserSerivce.GetAll().Where(a => a.UserName == userIdentification).Select(a => new SystemUserInfo
            //{
            //    Id = a.Id,
            //    UserName = a.UserName,
            //    FullName = a.FullName,
            //    Phone = a.Phone,
            //}).FirstOrDefault(); 
            var user = new UserInfo
            {
                UserName = userIdentification,
            };
            //if (user == null)
            //    return false;
            //TODO 从缓存中获取用户信息
            HttpContext.Current.GetOwinContext().Set(nameof(UserInfo), user);
            return true;
        }
    }
}

