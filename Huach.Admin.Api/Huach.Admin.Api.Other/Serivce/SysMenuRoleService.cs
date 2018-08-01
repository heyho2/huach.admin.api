using Huach.Admin.IRepository.Basic;
using Huach.Admin.Models.Basic;

namespace Huach.Admin.Service.Basic
{    
    /// <summary>
    /// SysMenuRoleService 
    /// </summary>
    public class SysMenuRoleService: ServiceBase<SysMenuRole>  
    {    
		private readonly ISysMenuRoleRepository _sysMenuRoleRepository;
		public SysMenuRoleService(ISysMenuRoleRepository sysMenuRoleRepository)
			:base(sysMenuRoleRepository)
		{
			_sysMenuRoleRepository = sysMenuRoleRepository;
		}
    }
}
    
