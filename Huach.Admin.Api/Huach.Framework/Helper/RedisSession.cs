using System;
using System.Web;

namespace Huach.Framework.Helper
{
    public class RedisSession<T>
    {
        public static RedisSession<T> Session => new RedisSession<T>();
        /// <summary>
        /// cookie名称
        /// </summary>
        public static string CookieName => "TOUYUNID";
        /// <summary>
        /// session过期时间
        /// 默认30分钟
        /// </summary>
        private Double SessionTimeOut { get; set; } = 30;

        public RedisSession<T> SetTimeOut(Double time)
        {
            this.SessionTimeOut = time;
            return this;
        }

        public T this[string name]
        {
            get
            {
                return Redis.RedisHelper.ClusterInstance.Get<T>(RedisKey, name);
            }
            set
            {
                Redis.RedisHelper.ClusterInstance.SetHash(RedisKey, name, value);
                Redis.RedisHelper.ClusterInstance.SetExpire(RedisKey, DateTime.Now.AddMinutes(SessionTimeOut));
            }
        }

        public void Remove(string name)
        {
            Redis.RedisHelper.ClusterInstance.Remove(RedisKey, name);
        }

        public void Add(string name, T value)
        {
            this[name] = value;
        }
        public T GetValue(string name)
        {
            return this[name];
        }
        /// <summary>
        /// session id
        /// </summary>
        public string SessionId
        {
            get
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies[CookieName];
                if (cookie != null)
                {
                    return cookie.Value;
                }
                else
                {
                    string sessionID = $"{DateTime.Now.ToString("MMdd")}{Guid.NewGuid().ToString("N")}";
                    cookie = new HttpCookie(CookieName, sessionID)
                    {
                        Expires = DateTime.Now.AddMinutes(SessionTimeOut)
                    };
                    HttpContext.Current.Response.Cookies.Set(cookie);
                    return sessionID;
                }
            }
        }
        /// <summary>
        ///清除session
        /// </summary>
        /// <returns></returns>
        public static bool Destroy()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[CookieName];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Set(cookie);
                return Redis.RedisHelper.ClusterInstance.KeyDelete($"Session:{CookieName}:{cookie.Value}");
            }
            return false;
        }
        public string RedisKey => $"Session:{CookieName}:{SessionId}";
    }
    public class RedisSession : RedisSession<string>
    {
    }
}
