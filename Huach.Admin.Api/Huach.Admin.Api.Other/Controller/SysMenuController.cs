using Huach.Admin.Models.Basic;
using Huach.Admin.Service.Basic;
using Huach.Framework.Models;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
namespace Huach.Admin.Api.Controllers.Basic
{    
    /// <summary>
    /// SysMenuController 
    /// </summary>
    public class SysMenuController: BaseApiController 
    {    
		private readonly SysMenuService _sysMenuService;
		public SysMenuController(SysMenuService sysMenuService)
		{
			_sysMenuService = sysMenuService;
		}
    }
}
    
