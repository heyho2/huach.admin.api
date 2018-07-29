using Huach.Admin.ViewModels;
using System.Web;
using System.Web.Http;

namespace Huach.Admin.Api.Controllers
{
    public class BaseApiController : Huach.Framework.Controllers.BaseApiController
    {
        /// <summary>
        /// 用户信息
        /// </summary>
        UserInfo CurrentUser => HttpContext.Current.GetOwinContext().Get<UserInfo>(nameof(UserInfo));

    }
}