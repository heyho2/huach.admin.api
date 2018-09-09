using Autofac.Integration.WebApi;
using Huach.Admin.Api.Config;
using Huach.Admin.Api.Filters;
using Huach.Framework;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using Swashbuckle.Application;
using System.Web.Http;

[assembly: OwinStartup(typeof(Huach.Admin.Api.Startup))]

namespace Huach.Admin.Api
{
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkID=316888
            HttpConfiguration config = new HttpConfiguration();

            WebApiConfig.Register(config);

            // Web API 认证授权，采用JWT标准。
            config.Filters.Add(new JwtAuthFilterAttribute());

            //model 验证
            config.Filters.Add(new ModelValidationFilterAttribute());

            //全局异常处理
            config.Filters.Add(new CustomExceptionFilterAttribute());

            SwaggerConfig.Register(config);

            // 设置默认的启动页为Swagger主页
            config.Routes.MapHttpRoute(
                name: "swagger_root",
                routeTemplate: "",
                defaults: null,
                constraints: null,
                handler: new RedirectHandler((message => message.RequestUri.ToString()), "swagger"));

            //AutoFact
            var container = AutoFactConfig.GetWebApiContainer();
            app.UseAutofacMiddleware(container);// 先注册autofac组件，需要依赖注入功能的组件在此后注册
            app.UseAutofacWebApi(config);//注册AutofacWebApi组件后再注册WebApi组件

            app.UseCors(CorsOptions.AllowAll);
             
            app.UseWebApi(config);
            //跨域

            var webApiResolver = new AutofacWebApiDependencyResolver(container);
            ServiceProvider.SetServiceProvider(new DependencyResolverServiceProvider(webApiResolver));

           

        }
    }
}
