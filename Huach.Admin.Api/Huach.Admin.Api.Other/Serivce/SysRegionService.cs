using Huach.Admin.IRepository.Basic;
using Huach.Admin.Models.Basic;

namespace Huach.Admin.Service.Basic
{    
    /// <summary>
    /// SysRegionService 
    /// </summary>
    public class SysRegionService: ServiceBase<SysRegion>  
    {    
		private readonly ISysRegionRepository _sysRegionRepository;
		public SysRegionService(ISysRegionRepository sysRegionRepository)
			:base(sysRegionRepository)
		{
			_sysRegionRepository = sysRegionRepository;
		}
    }
}
    
