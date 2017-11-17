namespace WEB.DependencyResolver
{
    using System;
    using System.Collections.Generic;
    using Ninject;
    using System.Web.Http.Dependencies;
    using Ninject.Extensions.ChildKernel;
    using BLL.Interfaces;
    using BLL.BLs;
    using DAL.Interfaces;
    using DAL.Interfaces.Implementations;
    using BLL.Mapping;

    public class NinjectResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectResolver() : this(new StandardKernel())
        {

        }

        public NinjectResolver(IKernel ninjectKernel, bool scope = false)
        {
            kernel = ninjectKernel;
            if (!scope)
            {
                AddBindings(kernel);
            }
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectResolver(AddRequestBindings(new ChildKernel(kernel)), true);
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        public void Dispose()
        {

        }

        private void AddBindings(IKernel kernel)
        {
            // singleton and transient bindings go here
        }

        private IKernel AddRequestBindings(IKernel kernel)
        {
            kernel.Bind<IUnitOfWorkFactory>().To<UnitOfWorkFactory>();
            kernel.Bind<IMapper>().To<Mapper>();

            kernel.Bind<IUserBL>().To<UserBL>();

            return kernel;
        }
    }
}