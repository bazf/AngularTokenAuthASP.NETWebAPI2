namespace WEB.DependencyResolver.MVCDependencyResolver
{
    using System;
    using System.Collections.Generic;

    public interface IMVCDependencyResolver
    {
        object GetService(Type serviceType);

        IEnumerable<object> GetServices(Type serviceType);
    }
}