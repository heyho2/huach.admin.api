using Huach.Admin.IRepository.Basic;
using Huach.Admin.Models;
using Huach.Admin.Models.Basic;
using System.Linq;

namespace Huach.Admin.Service.Basic
{
    /// <summary>
    /// SysUserService 
    /// </summary>
    public class SysUserService : ServiceBase<SysUser>
    {
        private readonly ISysUserRepository _sysUserRepository;
        private readonly ISysRoleRepository _sysRoleRepository;
        private readonly ISysUserRoleRepository _sysUserRoleRepository;
        public SysUserService(ISysUserRepository sysUserRepository, ISysRoleRepository sysRoleRepository, ISysUserRoleRepository sysUserRoleRepository)
            : base(sysUserRepository)
        {
            _sysUserRepository = sysUserRepository;
            _sysRoleRepository = sysRoleRepository;
            _sysUserRoleRepository = sysUserRoleRepository;
        }
        /// <summary>
        /// »ñÈ¡½ÇÉ«
        /// </summary>
        /// <returns></returns>
        public int[] GetRoles()
        {
            if (CurrentUser.IsManager)
            {
                return _sysRoleRepository.Where(a=>a.Disable == (short)ModelBase.DisableEnum.Normal).Select(a => a.Id).ToArray();
            }
            return _sysUserRoleRepository.Where(a => a.UserId == CurrentUser.Id && a.Disable == (short)ModelBase.DisableEnum.Normal).Select(a => a.RoleId).ToArray();
        }
    }
}

