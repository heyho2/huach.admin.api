﻿using Autofac;
using Autofac.Core;
using System;

namespace Huach.Framework.IOC
{
    public class ObjectContainer
    {
        public static Autofac.IContainer Container
        {
            get
            {
                return _container;
            }
        }

        private static Autofac.IContainer _container;

        private ObjectContainer()
        {
        }

        public static void Initialize(Action<ContainerBuilder> action)
        {
            var builder = new ContainerBuilder();

            if (action != null)
            {
                action(builder);
            }

            _container = builder.Build();
        }

        public static bool IsRegistered<TService>()
        {
            ThrowIfNotInitialized();
            return _container.IsRegistered<TService>();
        }

        public static bool IsRegistered(Type serviceType)
        {
            ThrowIfNotInitialized();
            return _container.IsRegistered(serviceType);
        }

        public static TService Resolve<TService>(params Parameter[] parameters)
        {
            ThrowIfNotInitialized();
            return _container.Resolve<TService>(parameters);
        }

        public static object Resolve(Type serviceType, params Parameter[] parameters)
        {
            ThrowIfNotInitialized();
            return _container.Resolve(serviceType, parameters);
        }

        public static TService ResolveNamed<TService>(string serviceName, params Parameter[] parameters)
        {
            ThrowIfNotInitialized();
            return _container.ResolveNamed<TService>(serviceName, parameters);
        }

        public static object ResolveNamed(string serviceName, Type serviceType, params Parameter[] parameters)
        {
            ThrowIfNotInitialized();
            return _container.ResolveNamed(serviceName, serviceType, parameters);
        }

        public static bool TryResolve<TService>(out TService service)
        {
            ThrowIfNotInitialized();
            return _container.TryResolve<TService>(out service);
        }

        public static bool TryResolve(Type serviceType, out object service)
        {
            ThrowIfNotInitialized();
            return _container.TryResolve(serviceType, out service);
        }

        private static void ThrowIfNotInitialized()
        {
            if (_container == null)
                throw new InvalidOperationException("Container should be initialized before using it.");
        }
    }
}
