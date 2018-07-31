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
    /// SysUserRoleController 
    /// </summary>
    public class SysUserRoleController: BaseApiController 
    {    
		private readonly SysUserRoleService _sysUserRoleService;
		public SysUserRoleController(SysUserRoleService sysUserRoleService)
		{
			_sysUserRoleService = sysUserRoleService;
		}
    }
}
    
