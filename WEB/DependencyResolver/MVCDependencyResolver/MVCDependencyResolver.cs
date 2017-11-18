namespace WEB.DependencyResolver.MVCDependencyResolver
{
    using System;
    using System.Collections.Generic;
    using Ninject;

    public class MVCDependencyResolver : IMVCDependencyResolver, System.Web.Mvc.IDependencyResolver
    {
        private IKernel kernel;

        public MVCDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}