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
    /// SysRegionController 
    /// </summary>
    public class SysRegionController: BaseApiController 
    {    
		private readonly SysRegionService _sysRegionService;
		public SysRegionController(SysRegionService sysRegionService)
		{
			_sysRegionService = sysRegionService;
		}
    }
}
    
