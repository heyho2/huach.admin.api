using Huach.Admin.Models;
using Huach.Admin.Models.Basic;
using Huach.Admin.Service;
using Huach.Admin.ViewModels;
using Huach.Framework.Models;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace Huach.Admin.Api.Controllers
{
    public class BaseApiController : Huach.Framework.Controllers.BaseApiController
    {
        /// <summary>
        /// 用户信息
        /// </summary>
        UserInfo CurrentUser => HttpContext.Current.GetOwinContext().Get<UserInfo>(nameof(UserInfo));
        
    }
    public class BaseApiController<T> : BaseApiController where T : BaseModel
    {
        private readonly BaseService<T> _service = null;
        public BaseApiController(BaseService<T> service)
        {
            _service = service;
        }
        
        [ResponseType(typeof(ActionResult<int>)), HttpGet]
        public virtual IHttpActionResult Delete(int id)
        {
            _service.Delete(a => a.Id == id);
            return Succeed();
        }
    }
}