using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huach.Framework
{
    public class ServiceProvider
    {
        private static IServiceProvider _serviceProvider;
        public static IServiceProvider Current
        {
            get
            {
                if (!ServiceProvider.IsServiceProviderSet)
                {
                    throw new InvalidOperationException("必须先调用SetServiceProvider赋值");
                }
                return ServiceProvider._serviceProvider;
            }
        }
        public static bool IsServiceProviderSet
        {
            get
            {
                return ServiceProvider._serviceProvider != null;
            }
        }
        public static void SetServiceProvider(IServiceProvider newProvider)
        {
            ServiceProvider._serviceProvider = newProvider;
        }
    }
}
