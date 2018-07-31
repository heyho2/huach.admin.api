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
    /// SysDictionaryTypeController 
    /// </summary>
    public class SysDictionaryTypeController: BaseApiController 
    {    
		private readonly SysDictionaryTypeService _sysDictionaryTypeService;
		public SysDictionaryTypeController(SysDictionaryTypeService sysDictionaryTypeService)
		{
			_sysDictionaryTypeService = sysDictionaryTypeService;
		}
    }
}
    
