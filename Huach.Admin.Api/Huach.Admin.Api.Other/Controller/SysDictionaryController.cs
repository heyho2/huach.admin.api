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
    /// SysDictionaryController 
    /// </summary>
    public class SysDictionaryController: BaseApiController 
    {    
		private readonly SysDictionaryService _sysDictionaryService;
		public SysDictionaryController(SysDictionaryService sysDictionaryService)
		{
			_sysDictionaryService = sysDictionaryService;
		}
    }
}
    
