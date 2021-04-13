using Ninject;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
            AddBindings();
        }

        private void AddBindings()
        {
            // 여기에 바인딩 정보를 입력한다.

            // Ninject 에 IProductRepository 인터페이스에 대한 요청이 전달되면, EFProductRepository 클래스의 인스턴스를 생성해서 제공하도록 지시한다.
            kernel.Bind<IProductRepository>().To<EFProductRepository>();
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