using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;

namespace Huach.Framework.Models
{
    public abstract class BaseTokenAuthFilterAttribute : BaseAuthFilterAttribute
    {
        protected virtual string TokenKeyName
        {
            get
            {
                return "Authorization";
            }
        }
        protected virtual string GetToken(HttpActionContext actionContext)
        {
            return actionContext.Request.Headers.GetValues(TokenKeyName).FirstOrDefault();
        }
        protected override string GetUserIdentification(HttpActionContext actionContext)
        {
            return this.GetToken(actionContext);
        }
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (this.IsAllowAnonymous(actionContext))
            {
                return;
            }
            if (this.IsAuthenticated(this.GetToken(actionContext)))
            {
                base.OnAuthorization(actionContext);
                return;
            }
            this.HandleUnauthenticatedRequest(actionContext, null);
        }
        protected abstract bool IsAuthenticated(string token);
    }
}
