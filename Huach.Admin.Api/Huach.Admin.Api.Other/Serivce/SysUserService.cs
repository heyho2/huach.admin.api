using Huach.Admin.IRepository.Basic;
using Huach.Admin.Models.Basic;

namespace Huach.Admin.Service.Basic
{    
    /// <summary>
    /// SysUserService 
    /// </summary>
    public class SysUserService: ServiceBase<SysUser>  
    {    
		private readonly ISysUserRepository _sysUserRepository;
		public SysUserService(ISysUserRepository sysUserRepository)
			:base(sysUserRepository)
		{
			_sysUserRepository = sysUserRepository;
		}
    }
}
    
