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
    /// SysRoleController 
    /// </summary>
    public class SysRoleController: BaseApiController 
    {    
		private readonly SysRoleService _sysRoleService;
		public SysRoleController(SysRoleService sysRoleService)
		{
			_sysRoleService = sysRoleService;
		}
    }
}
    
