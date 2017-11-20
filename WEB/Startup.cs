using Microsoft.Owin;
using Owin;
using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Hosting.Services;
using WEB.Providers;
using BLL.Interfaces.IServices;
using WEB.DependencyResolver;

[assembly: OwinStartup(typeof(WEB.Startup))]
namespace WEB
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            IoC.Configure(NinjectWebCommon.Kernel);
            DependencyRegistrator.RegisterBindings(NinjectWebCommon.Kernel);

            ConfigureOAuth(app);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                Provider = new DevComTestAuthProvider(NinjectWebCommon.Kernel.GetService<IAuthenticationService>()),
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            NinjectWebCommon.Kernel.GetService<IAuthenticationService>().RegisterDefaultUsers();
        }
    }
}
