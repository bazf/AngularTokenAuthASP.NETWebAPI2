namespace WEB.DependencyResolver
{
    using System;
    using System.Web;
    using System.Web.Http;
    using Ninject;
    using Ninject.Web.Common;

    public static class IoC
    {
        public static void Configure(IKernel kernel)
        {
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            // for WebAPI
            GlobalConfiguration.Configuration.DependencyResolver = new WebAPINinjectDependencyResolver(kernel);

            // for MVC
            System.Web.Mvc.DependencyResolver.SetResolver(new MVCDependencyResolver.MVCDependencyResolver(kernel));
        }
    }
}