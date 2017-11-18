namespace WEB.DependencyResolver
{
    using System.Web.Http.Dependencies;
    using Ninject;

    public class WebAPINinjectDependencyResolver : WebAPINinjectDependencyScope, IDependencyResolver
    {
        private IKernel kernel;

        public WebAPINinjectDependencyResolver(IKernel kernel)
            : base(kernel)
        {
            this.kernel = kernel;
        }

        public IDependencyScope BeginScope()
        {
            return new WebAPINinjectDependencyScope(kernel.BeginBlock());
        }
    }
}