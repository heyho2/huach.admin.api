using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Huach.Framework.Models
{

    public abstract class BaseAuthFilterAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            string userIdentification = GetUserIdentification(actionContext);
            Type controllerType = actionContext.ActionDescriptor.ControllerDescriptor.ControllerType;
            string actionName = actionContext.ActionDescriptor.ActionName;
            if (!IsAuthorized(userIdentification, controllerType, actionName))
            {
                this.HandleUnauthorizedRequest(actionContext);
            }
        }

        protected virtual bool IsAllowAnonymous(HttpActionContext actionContext)
        {
            bool flag = false;
            flag = actionContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();
            if (!flag)
            {
                flag = actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();
            }
            return flag;
        }

        protected virtual void HandleUnauthenticatedRequest(HttpActionContext actionContext, string msg = null)
        {
            ActionResult actionResult = ActionResult.Fail($"由于身份验证失败，请求被拒绝。{msg}");
            actionResult.HttpStatusCode = HttpStatusCode.Unauthorized;
            actionResult.SubHttpStatusCode = 1;
            actionContext.Response = actionResult.ToHttpResponseMessage();
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            this.HandleUnauthorizedRequest(actionContext);
            ActionResult actionResult = ActionResult.Fail("该请求因无法访问该资源而被拒绝。");
            actionResult.HttpStatusCode = HttpStatusCode.Unauthorized;
            actionResult.SubHttpStatusCode = 3;
            actionContext.Response = actionResult.ToHttpResponseMessage();
        }

        protected abstract string GetUserIdentification(HttpActionContext actionContext);

        protected virtual bool IsAuthorized(string userIdentification, Type controllerType, string actionName)
        {
            return true;
        }
    }
}
