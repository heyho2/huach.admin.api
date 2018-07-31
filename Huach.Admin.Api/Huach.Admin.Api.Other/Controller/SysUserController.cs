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
    /// SysUserController 
    /// </summary>
    public class SysUserController: BaseApiController 
    {    
		private readonly SysUserService _sysUserService;
		public SysUserController(SysUserService sysUserService)
		{
			_sysUserService = sysUserService;
		}
    }
}
    
