using Files;
using Ninject;
using Ninject.Extensions.ChildKernel;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

namespace api_imagex_converter.DI
{
    public class NinjectResolver : IDependencyResolver
    {
        #region Private Members

        private IKernel kernel;

        #endregion

        #region Constructor

        public NinjectResolver() : this(new StandardKernel()) { }

        public NinjectResolver(IKernel ninjectKernel, bool scope = false)
        {
            kernel = ninjectKernel;
            if (!scope)
            {
                AddBindings(kernel);
            }
        }

        #endregion

        #region Ninject Methods

        public IDependencyScope BeginScope() => new NinjectResolver(ServiceBinding(new ChildKernel(kernel)), true);

        public void Dispose() => kernel.Dispose();

        public object GetService(Type serviceType) => kernel.TryGet(serviceType);

        public IEnumerable<object> GetServices(Type serviceType) => kernel.GetAll(serviceType);

        #endregion

        #region Private Helpers

        private IKernel ServiceBinding(IKernel kernel)
        {
            kernel.Bind<IFileManager>().To<FileManager>().InSingletonScope();
            return kernel;
        }

        private void AddBindings(IKernel kernel)
        {
            // singleton and transient bindings go here
        }

        #endregion
    }
}