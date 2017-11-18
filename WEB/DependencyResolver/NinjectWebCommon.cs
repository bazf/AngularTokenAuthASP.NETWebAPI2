[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(WEB.DependencyResolver.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(WEB.DependencyResolver.NinjectWebCommon), "Stop")]

namespace WEB.DependencyResolver
{
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        public static IKernel Kernel { get; private set; }

        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }

        public static void Stop()
        {
            Bootstrapper.ShutDown();
        }

        public static IKernel CreateKernel()
        {
            Kernel = new StandardKernel();

            try
            {
                return Kernel;
            }
            catch
            {
                Kernel.Dispose();
                throw;
            }
        }
    }
}
