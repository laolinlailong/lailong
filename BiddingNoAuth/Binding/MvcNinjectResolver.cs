using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blogging.Data;
using Blogging.Services;
using Blogging.Services.ImplementedInterfaces.Queries;
using Blogging.Services.ImplementedInterfaces.Services;
using Ninject;
using Ninject.Web.Common;

namespace BiddingNoAuth.Binding
{
    public class MvcNinjectResolver : System.Web.Mvc.IDependencyResolver
    {
        private readonly IKernel _kernel;

        public MvcNinjectResolver()
            : this(new StandardKernel())
        {
        }

        public MvcNinjectResolver(IKernel ninjectKernel)
        {
            _kernel = ninjectKernel;

            _kernel.Bind<BloggingDbContext>().ToSelf().InRequestScope();
            _kernel.Bind<IBlogQuery>().To<BlogQuery>().InRequestScope();
            _kernel.Bind<IBlogService>().To<BlogService>().InRequestScope();

        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public T GetService<T>()
        {
            return _kernel.TryGet<T>();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        public void Dispose()
        {
        }
    }
}