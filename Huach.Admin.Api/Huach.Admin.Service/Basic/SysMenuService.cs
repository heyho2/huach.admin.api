using Huach.Admin.IRepository.Basic;
using Huach.Admin.Models.Basic;

namespace Huach.Admin.Service.Basic
{    
    /// <summary>
    /// SysMenuService 
    /// </summary>
    public class SysMenuService: BaseService<SysMenu>  
    {    
		private readonly ISysMenuRepository _sysMenuRepository;
		public SysMenuService(ISysMenuRepository sysMenuRepository)
			:base(sysMenuRepository)
		{
			_sysMenuRepository = sysMenuRepository;
		}
    }
}
    
