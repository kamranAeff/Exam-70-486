using Chapter06.WebUI.Models;
using Ninject;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Chapter06.WebUI.AppCode.Config
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver()
            :this(new StandardKernel())
        {
        }

        public NinjectDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            //kernel.Bind<IValueCalculator>().To<LinqValueCalculator>().InTransientScope();//her defe yeni nusxe
            //kernel.Bind<IValueCalculator>().To<LinqValueCalculator>().InSingletonScope();//1  defe yeni nusxe
            //kernel.Bind<IValueCalculator>().To<LinqValueCalculator>().InRequestScope();//her requestde 1  defe yeni nusxe
            kernel.Bind<IValueCalculator>().To<LinqValueCalculator>().InThreadScope();//her requestde 1  defe yeni nusxe
            //kernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>().WithPropertyValue("DiscountSize", 50M);
            kernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>().WithConstructorArgument("discountSize", 50M);
            kernel.Bind<IDiscountHelper>().To<FlexibleDiscountHelper>().WhenInjectedInto<LinqValueCalculator>();
        }
    }
}