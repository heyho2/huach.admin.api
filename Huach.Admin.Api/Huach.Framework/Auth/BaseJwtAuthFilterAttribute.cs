using Huach.Framework.Jwt;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Controllers;

namespace Huach.Framework.Models
{
    public abstract class BaseJwtAuthFilterAttribute : BaseAuthFilterAttribute
    {
        protected abstract string Secret { get; }
        protected virtual string JwtTokenKeyName { get; } = "Authorization";
        protected virtual string GetJwtToken(HttpActionContext actionContext)
        {
            return actionContext.Request.Headers.GetValues(JwtTokenKeyName).FirstOrDefault();
        }
        protected abstract string GetUserIdentification(IDictionary<string, object> jwtPayload);
        protected override string GetUserIdentification(HttpActionContext actionContext)
        {
            object UserIdentification = actionContext.ActionArguments["UserIdentification"];
            if (UserIdentification == null)
            {
                return null;
            }
            return UserIdentification.ToString();
        }
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (this.IsAllowAnonymous(actionContext))
            {
                return;
            }
            bool flag = false;
            string msg = null;
            string jwtToken = this.GetJwtToken(actionContext);
            if (!string.IsNullOrWhiteSpace(jwtToken))
            {
                JwtDecode<Dictionary<string, object>> jwtDecodeInfo = JwtHelper.Decode(jwtToken, this.Secret);
                msg = jwtDecodeInfo.Msg;
                if (jwtDecodeInfo.IsSucceed)
                {
                    string userIdentification = this.GetUserIdentification(jwtDecodeInfo.Payload);
                    if (this.IsAuthenticated(userIdentification, jwtDecodeInfo.Payload))
                    {
                        flag = true;
                        actionContext.ActionArguments["UserIdentification"] = userIdentification;
                        base.OnAuthorization(actionContext);
                    }
                }
            }
            if (!flag)
            {
                this.HandleUnauthenticatedRequest(actionContext, msg);
            }
        }
        protected abstract bool IsAuthenticated(string userIdentification, IDictionary<string, object> jwtPayload);
    }
}
