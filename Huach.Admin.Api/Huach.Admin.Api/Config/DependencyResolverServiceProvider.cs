using System;
using System.Web.Http.Dependencies;

namespace Huach.Admin.Api.Config
{
    internal class DependencyResolverServiceProvider : IServiceProvider
    {
        private readonly IDependencyResolver _resolver;
        public DependencyResolverServiceProvider(IDependencyResolver resolver)
        {
            _resolver = resolver;
        }

        public object GetService(Type serviceType)
        {
            return _resolver.GetService(serviceType);
        }
    }
}