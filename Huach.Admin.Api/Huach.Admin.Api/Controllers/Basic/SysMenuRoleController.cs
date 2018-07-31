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
    /// SysMenuRoleController 
    /// </summary>
    public class SysMenuRoleController: BaseApiController 
    {    
		private readonly SysMenuRoleService _sysMenuRoleService;
		public SysMenuRoleController(SysMenuRoleService sysMenuRoleService)
		{
			_sysMenuRoleService = sysMenuRoleService;
		}
    }
}
    
