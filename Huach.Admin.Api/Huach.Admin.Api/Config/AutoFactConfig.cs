using Autofac;
using Autofac.Integration.WebApi;
using Huach.Framework;
using Microsoft.Framework.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace Huach.Admin.Api.Config
{
    public static class AutoFactConfig
    {
        public static IContainer GetWebApiContainer()
        {
            //注册主项目的ApiControllers
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //注入所有的服务
            builder.RegisterAssemblyTypes(GetAllAssemblys())
                   .Where(t => typeof(IService).IsAssignableFrom(t))
                   .AsImplementedInterfaces().PropertiesAutowired().AsSelf();

            //注册AppSettings
            var configurationBuilder = new ConfigurationBuilder();
            AddAppSettings(configurationBuilder);
            builder.RegisterInstance(configurationBuilder.Build()).As<IConfiguration>().SingleInstance();

            ////注册缓存
            //builder.RegisterType<MemoryCacheFactory>().As<ICacheFactory>().SingleInstance();

            //ApiInitializer.RegisterTypes(builder);


            return builder.Build();
        }
        public static IConfigurationBuilder AddAppSettings(IConfigurationBuilder configuration)
        {
            configuration.Add(new AppSettingConfigurationProvider());
            return configuration;
        }
        private static Assembly[] GetAllAssemblys()
        {
            var assemblys = new List<Assembly>();
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin");
            foreach (var file in Directory.GetFiles(path, "*.dll"))
            {
                if (!Path.GetFileName(file).StartsWith("System"))
                {
                    assemblys.Add(Assembly.LoadFrom(file));
                }
            }
            return assemblys.ToArray();
        }
    }
    internal class AppSettingConfigurationProvider : ConfigurationProvider
    {
        public override void Load()
        {
            Load(ConfigurationManager.AppSettings);
        }

        private void Load(NameValueCollection appSettings)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            string[] allKeys = appSettings.AllKeys;
            foreach (string text in allKeys)
            {
                dictionary.Add(text, appSettings[text]);
            }
            base.Data = dictionary;
        }
    }
}