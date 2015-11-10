using System;
using System.Collections.Generic;
using Ninject;
using System.Web.Mvc;
using Moq;
using System.Linq;
using SportsStore.Domain.Entities;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Concrete;

namespace SportStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        private void AddBindings()
        {
            //Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            //mock.Setup(m => m.Products).Returns(new List<Product>
            //{
            //    new Product{Name = "FootBall", Price = 25},
            //    new Product{Name = "Surf board", Price = 179},
            //    new Product{Name = "Running Shoes", Price = 95},
            //});

            kernel.Bind<IProductsRepository>().To<EFProductRepository>();
            kernel.Bind<ICustomerRepository>().To<EFCustomerRepository>();
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