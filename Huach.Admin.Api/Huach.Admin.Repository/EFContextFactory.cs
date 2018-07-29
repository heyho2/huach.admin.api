using System.Data.Entity;
using System.Runtime.Remoting.Messaging;

namespace Huach.Admin.Repository
{
    public class EFContextFactory
    {
        private EFContextFactory() { }
        /// <summary>
        /// 保证了线程内DbSession实例唯一
        /// </summary>
        public static DbContext GetCurrentDbContext
        {
            get
            {
                DbContext context = CallContext.GetData(nameof(DbContext)) as HuachContext;
                if (context == null)
                {
                    context = new HuachContext();
                    //将值设置到数据槽里面去
                    CallContext.SetData(nameof(DbContext), context);
                }
                return context;
            }
        }
        public static DbContext NewEFContext()
        {
            return new HuachContext();
        }
    }
}
