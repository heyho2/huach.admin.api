using Huach.Admin.IRepository.Basic;
using Huach.Admin.Models.Basic;

namespace Huach.Admin.Service.Basic
{    
    /// <summary>
    /// SysUserRoleService 
    /// </summary>
    public class SysUserRoleService: BaseService<SysUserRole>  
    {    
		private readonly ISysUserRoleRepository _sysUserRoleRepository;
		public SysUserRoleService(ISysUserRoleRepository sysUserRoleRepository)
			:base(sysUserRoleRepository)
		{
			_sysUserRoleRepository = sysUserRoleRepository;
		}
    }
}
    
