using Huach.Admin.IRepository.Basic;
using Huach.Admin.Models.Basic;

namespace Huach.Admin.Service.Basic
{    
    /// <summary>
    /// SysRoleService 
    /// </summary>
    public class SysRoleService: BaseService<SysRole>  
    {    
		private readonly ISysRoleRepository _sysRoleRepository;
		public SysRoleService(ISysRoleRepository sysRoleRepository)
			:base(sysRoleRepository)
		{
			_sysRoleRepository = sysRoleRepository;
		}
    }
}
    
