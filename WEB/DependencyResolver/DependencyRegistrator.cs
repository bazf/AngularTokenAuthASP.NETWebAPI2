namespace WEB.DependencyResolver
{
    using BLL.BLs;
    using BLL.Interfaces.IBLs;
    using BLL.Interfaces.IServices;
    using BLL.Mapping;
    using BLL.Services;
    using DAL.Interfaces;
    using DAL.Interfaces.Implementations;
    using Ninject;

    public static class DependencyRegistrator
    {
        public static void RegisterBindings(IKernel kernel)
        {
            kernel.Bind<IAuthenticationService>().To<AuthenticationService>();
            kernel.Bind<IUnitOfWorkFactory>().To<UnitOfWorkFactory>();
            kernel.Bind<IMapper>().To<Mapper>();

            kernel.Bind<IUserBL>().To<UserBL>();

        }
    }
}