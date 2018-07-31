using Huach.Admin.IRepository.Basic;
using Huach.Admin.Models.Basic;

namespace Huach.Admin.Service.Basic
{    
    /// <summary>
    /// SysLogsService 
    /// </summary>
    public class SysLogsService: ServiceBase<SysLogs>  
    {    
		private readonly ISysLogsRepository _sysLogsRepository;
		public SysLogsService(ISysLogsRepository sysLogsRepository)
			:base(sysLogsRepository)
		{
			_sysLogsRepository = sysLogsRepository;
		}
    }
}
    
