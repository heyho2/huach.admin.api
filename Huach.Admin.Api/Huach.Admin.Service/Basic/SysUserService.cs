using Huach.Admin.IRepository.Basic;
using Huach.Admin.Models.Basic;

namespace Huach.Admin.Service.Basic
{
    public class SysUserService : ServiceBase<SysUser>
    {
        private readonly ISysUserRepository _sysUserRepository = null;
        public SysUserService(ISysUserRepository sysUserRepository)
            :base(sysUserRepository)
        {
            //我这里发生了变化,这里又发生了改变
            _sysUserRepository = sysUserRepository;

        }
    }
}
