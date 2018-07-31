using Huach.Admin.Models.Basic;
using Huach.Admin.Models.Business;
using Huach.Framework.Log;
using System.Data.Entity;

namespace Huach.Admin.Repository
{
    public class HuachContext : DbContext
    {
        private Logger logger = Logger.CreateLogger(typeof(HuachContext));
        public HuachContext() : base("name=HuachConnection")
        {
            Database.Log = msg => logger.Debug(msg);
        }
        static HuachContext()
        {
            Database.SetInitializer<HuachContext>(null);
            //修复bin目录下没有自动引入EntityFramework.SqlServer.dll
            FixEfProviderServicesProblem();
        }

        private static void FixEfProviderServicesProblem()
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public virtual DbSet<SysUser> SysUserInfoSet { get; set; }
        public virtual DbSet<SysUserRole> SysUserRoleSet { get; set; }
        public virtual DbSet<SysDictionary> SysDictionarySet { get; set; }
        public virtual DbSet<SysDictionaryType> SysDictionaryTypeSet { get; set; }
        public virtual DbSet<SysMenu> SysMenuSet { get; set; }
        public virtual DbSet<SysMenuRole> SysMenuRoleSet { get; set; }
        public virtual DbSet<SysRegion> SysRegionSet { get; set; }
        public virtual DbSet<SysRole> SysRoleSet { get; set; }
        public virtual DbSet<SysLogs> SysLogsSet { get; set; }
        public virtual DbSet<AdvertisingImage> AdvertisingImageSet { get; set; }
        public virtual DbSet<Company> CompanySet { get; set; }
        public virtual DbSet<News> NewsSet { get; set; }
        public virtual DbSet<Product> ProductSet { get; set; }
        public virtual DbSet<ProductAttr> ProductAttrSet { get; set; }
        public virtual DbSet<ProductType> ProductTypeSet { get; set; }

    }
}
